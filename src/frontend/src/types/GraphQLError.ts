export type GraphQLError = {
  message?: string;
  extensions?: {
    code?: string;
  };
};

export type RelayGraphQLError = {
  source?: {
    errors?: GraphQLError[];
  };
};
