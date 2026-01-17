import z from "zod";
import { useForm } from "@tanstack/react-form";
import {
  Field,
  FieldDescription,
  FieldGroup,
  FieldLabel,
  FieldLegend,
  FieldSet,
} from "../../ui/field";
import { Input } from "../../ui/input";
import {
  AlertCircle,
  ArrowLeft,
  CloudDownload,
  Cookie,
  IdCard,
  Info,
} from "lucide-react";
import { Alert, AlertDescription, AlertTitle } from "../../ui/alert";
import { CookieGuide } from "./CookieGuide";
import { Label } from "../../ui/label";
import { LeagueIdGuide } from "./LeagueIdGuide";
import { ConnectionHandler, graphql } from "relay-runtime";
import { FormEvent, useEffect, useRef, useState } from "react";
import { Button } from "@/components/ui/button";
import { useMutation } from "react-relay";
import { ESPNFormAddLeagueMutation } from "@/__generated__/ESPNFormAddLeagueMutation.graphql";
import { Spinner } from "@/components/ui/spinner";
import { FormFieldError } from "@/components/shared/FormFieldError";

type Props = {
  resetEntry: () => void;
  onCompletion: () => void;
  userId: string;
};

const espnSchema = z.object({
  leagueId: z
    .number({ invalid_type_error: "League Id must be a number" })
    .int("Your league ID should be a whole number")
    .positive("League Id must be positive"),
  swid: z
    .string()
    .min(1, "SWID is required")
    .regex(
      /^\{[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}\}$/,
      "Must include curly braces: {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}",
    ),
  espnS2Id: z.string().min(1, "ESPN S2 is required"),
});

const addESPNLeagueMutation = graphql`
  mutation ESPNFormAddLeagueMutation(
    $espnCredentials: AddESPNLeagueToUserInput!
    $connections: [ID!]!
  ) {
    addESPNLeagueToUser(input: $espnCredentials) {
      addLeagueMutationPayload {
        jobId
        import
          @appendNode(
            connections: $connections
            edgeTypeName: "LeagueImportsEdge"
          ) {
          id
          ...PendingLeagueCardFragment
        }
      }
      errors {
        ... on ICodedException {
          errorCode
          message
        }
      }
    }
  }
`;

export function ESPNForm({ resetEntry, onCompletion, userId }: Props) {
  const [serverErrors, setServerErrors] = useState<string[]>([]);
  const [commitNewLeague, newLeagueIsPending] =
    useMutation<ESPNFormAddLeagueMutation>(addESPNLeagueMutation);

  const errorTopRef = useRef<HTMLDivElement>(null);

  const form = useForm({
    defaultValues: {
      leagueId: 19116,
      swid: "{2B552365-1B96-4AB6-9FC2-825638611F76}",
      espnS2Id:
        "AEBcJaRL9ejJ4YXBKu52KAxehgBoK3U1JprZ0IU9LVwpmTSpP1wjHtljmwWpc7E0ukSCVOShqiNbZR0FVLM6p99f6%2F3lYJ%2F82LExKH%2FGAcGxGP02JJV5%2BDby20j1v4unh7mehK2nrPrj3koKq1TAnVGrF84Ln6YbtaYwcvXqf2dvo2RSTmMIcwtDnlwwegBLKSL4BhCEp2m42XnhZ8POv%2FwZohLkCADZ%2FaVSPSbAssRU7BxliEynoga6IBHPIjIbpuzual845%2FnZKFS2LLweXsSAKVm3JSdOm3z6E2lh0oKnOl8X89pVEadPlv30uwQ7sbg%3D",
    },
    validators: {
      onChange: espnSchema,
    },
    onSubmit: (form) => {
      setServerErrors([]);

      commitNewLeague({
        variables: {
          espnCredentials: {
            leagueId: form.value.leagueId.toString(),
            espnS2Id: form.value.espnS2Id,
            swid: form.value.swid,
          },
          connections: [
            ConnectionHandler.getConnectionID(userId, "my_leagueImports"),
          ],
        },
        onCompleted: (response, _) => {
          console.log(response);
          if (
            response.addESPNLeagueToUser.errors &&
            response.addESPNLeagueToUser.errors.length > 0
          ) {
            setServerErrors(
              response.addESPNLeagueToUser.errors.map(
                (error) => error.message ?? "",
              ),
            );
          } else {
            onCompletion();
          }
        },
      });
    },
  });

  useEffect(() => {
    if (serverErrors.length > 0 && errorTopRef.current) {
      errorTopRef.current.scrollIntoView({
        behavior: "smooth",
        block: "start",
      });
    }
  }, [serverErrors]);

  const onFormSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    e.stopPropagation();

    form.handleSubmit();
  };

  return (
    <form className="relative flex flex-col gap-6" onSubmit={onFormSubmit}>
      <div
        ref={errorTopRef}
        className="absolute top-0 left-0 w-0 h-0"
        aria-hidden="true"
      />
      {serverErrors.length > 0 && (
        <Alert variant="destructive" className="border-destructive">
          <AlertCircle className="h-4 w-4" />
          <AlertTitle>Import Failed</AlertTitle>
          <AlertDescription>
            <ul className="list-disc pl-4">
              {serverErrors.map((err, i) => (
                <li key={i}>{err}</li>
              ))}
            </ul>
          </AlertDescription>
        </Alert>
      )}
      <FieldGroup>
        <FieldSet>
          <FieldLegend>League Identification</FieldLegend>
          <FieldDescription>Tell us which league to import</FieldDescription>
          <LeagueIdGuide />
          <form.Field name="leagueId">
            {(field) => (
              <div className="space-y-2">
                <Label htmlFor={field.name}>
                  <IdCard className="size-5 text-muted-foreground" /> ESPN
                  League ID
                </Label>
                <FormFieldError field={field} />
                <Input
                  id={field.name}
                  type="number"
                  placeholder="12345678"
                  value={field.state.value ?? ""}
                  onChange={(e) => {
                    const val = e.target.value;
                    field.handleChange(
                      val
                        ? parseInt(val, 10)
                        : (undefined as unknown as number),
                    );
                  }}
                  onBlur={field.handleBlur}
                />
              </div>
            )}
          </form.Field>
        </FieldSet>
        <FieldSet>
          <FieldLegend>League Authentication</FieldLegend>
          <FieldDescription>
            Credentials to authenticate with ESPN
          </FieldDescription>
          <Alert className="-mt-2">
            <Info className="stroke-sky-400" />
            <AlertTitle>Credentials notice</AlertTitle>
            <AlertDescription>
              Fantasy HOF never saves or logs the values you enter below. They
              are only used to authenticate with ESPN and then are promptly
              discarded.
            </AlertDescription>
          </Alert>
          <CookieGuide />
          <form.Field
            name="swid"
            children={(field) => (
              <Field>
                <div className="flex flex-row gap-2 items-center">
                  <FieldLabel htmlFor="espn-league-id">
                    <Cookie className="size-4 text-muted-foreground" />
                    SWID
                  </FieldLabel>
                </div>
                <FormFieldError field={field} />
                <Input
                  id={field.name}
                  placeholder="{A1234-B456-C789-D012-E01234567890}"
                  value={field.state.value ?? ""}
                  onChange={(e) => field.handleChange(e.target.value)}
                  onBlur={field.handleBlur}
                />
              </Field>
            )}
          />
          <form.Field
            name="espnS2Id"
            children={(field) => (
              <Field>
                <FieldLabel htmlFor="espn-league-id">
                  <Cookie className="size-4 text-muted-foreground" />
                  ESPN S2
                </FieldLabel>
                {field.state.meta.isBlurred &&
                  !field.state.meta.isDefaultValue &&
                  field.state.meta.errors.length > 0 && (
                    <p className="text-sm text-destructive">
                      {field.state.meta.errors
                        .map((x) => x?.message)
                        .join(", ")}
                    </p>
                  )}
                <Input
                  id={field.name}
                  placeholder="AB123AB113AB23..."
                  value={field.state.value ?? ""}
                  onChange={(e) => field.handleChange(e.target.value)}
                  onBlur={field.handleBlur}
                />
              </Field>
            )}
          />
        </FieldSet>
      </FieldGroup>
      <div className="flex flex-row gap-x-4 *:w-[50%] justify-center">
        <Button
          className="bg-muted-foreground hover:bg-muted-foreground/80"
          onClick={resetEntry}
        >
          <ArrowLeft />
          Head back
        </Button>
        <Button disabled={newLeagueIsPending}>
          Import
          {newLeagueIsPending ? <Spinner /> : <CloudDownload />}
        </Button>
      </div>
    </form>
  );
}
