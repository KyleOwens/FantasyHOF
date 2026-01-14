import { AnyFieldApi } from "@tanstack/react-form";
import { FieldError } from "../ui/field";

type Props = {
  field: AnyFieldApi;
};

export function FormFieldError({ field }: Props) {
  return (
    <>
      {field.state.meta.isBlurred &&
        !field.state.meta.isDefaultValue &&
        field.state.meta.errors.length > 0 && (
          <FieldError>
            {field.state.meta.errors.map((x) => x?.message).join(", ")}
          </FieldError>
        )}
    </>
  );
}
