import { clsx, type ClassValue } from "clsx";
import { twMerge } from "tailwind-merge";

export function cn(...inputs: ClassValue[]) {
  return twMerge(clsx(inputs));
}

export function getLeagueIdFromUrl(url: string): string | undefined {
  const match = url.match(/leagueId=(\d+)/);
  return match ? match[1] : undefined;
}
