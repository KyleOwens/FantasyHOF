import { RelayGraphQLError } from "@/types/GraphQLError";

export function isRelayError(error: unknown): error is RelayGraphQLError {
  return (
    typeof error === "object" &&
    error !== null &&
    "source" in error &&
    typeof (error as any).source === "object" &&
    (error as any).source !== null &&
    Array.isArray((error as any).source.errors)
  );
}
