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
import { ArrowLeft, Check, Cookie, IdCard, Info } from "lucide-react";
import { Alert, AlertDescription, AlertTitle } from "../../ui/alert";
import { CookieGuide } from "./CookieGuide";
import { Label } from "../../ui/label";
import { LeagueIdGuide } from "./LeagueIdGuide";
import { graphql } from "relay-runtime";
import { FormEvent } from "react";
import { Button } from "@/components/ui/button";
import { useMutation } from "react-relay";
import { ESPNFormAddLeagueMutation } from "@/__generated__/ESPNFormAddLeagueMutation.graphql";

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
  ) {
    addESPNLeagueToUser(input: $espnCredentials) {
      league {
        id
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

export function ESPNForm() {
  const [addESPNLeague, isPending] = useMutation<ESPNFormAddLeagueMutation>(
    addESPNLeagueMutation,
  );

  const form = useForm({
    defaultValues: {
      leagueId: undefined as unknown as number,
      swid: "",
      espnS2Id: "",
    },
    validators: {
      onBlur: espnSchema,
    },
    onSubmit: (form) => {
      console.log(form.value.swid);

      addESPNLeague({
        variables: {
          espnCredentials: {
            leagueId: form.value.leagueId.toString(),
            espnS2Id: form.value.espnS2Id,
            swid: form.value.swid,
          },
        },
        onCompleted: (response, errors) => {
          if (errors) console.error("GraphQL errors: ", errors);
        },
      });
    },
  });

  const onFormSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    e.stopPropagation();

    form.handleSubmit();
  };

  return (
    <form className="flex flex-col gap-6" onSubmit={onFormSubmit}>
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
                {field.state.meta.isTouched &&
                  field.state.meta.errors.length > 0 && (
                    <p className="text-sm text-destructive">
                      {field.state.meta.errors
                        .map((x) => x?.message)
                        .join(", ")}
                    </p>
                  )}
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
          <Alert>
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
                    League Id
                  </FieldLabel>
                </div>
                {field.state.meta.isTouched &&
                  field.state.meta.errors.length > 0 && (
                    <p className="text-sm text-destructive">
                      {field.state.meta.errors
                        .map((x) => x?.message)
                        .join(", ")}
                    </p>
                  )}
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
                {field.state.meta.isTouched &&
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
        <Button className="bg-muted-foreground hover:bg-muted-foreground/80 ">
          <ArrowLeft />
          Head back
        </Button>
        <Button disabled={isPending}>
          Submit
          <Check />
        </Button>
      </div>
    </form>
  );
}
