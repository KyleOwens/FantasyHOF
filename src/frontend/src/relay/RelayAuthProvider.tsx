// components/RelayAuthProvider.tsx
import { useAuth } from "@clerk/clerk-react";
import { useEffect } from "react";
import { setTokenGetter } from "@/relay/RelayEnvironment";

export function RelayAuthProvider({ children }: { children: React.ReactNode }) {
  const { getToken } = useAuth();

  useEffect(() => {
    setTokenGetter(getToken);
  }, [getToken]);

  return <>{children}</>;
}
