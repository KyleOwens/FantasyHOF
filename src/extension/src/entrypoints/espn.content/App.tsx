import { useEffect, useState } from "react";
import { cn, getLeagueIdFromUrl } from "@/lib/utils";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Copy, Check, ChevronUp, Database, IdCard } from "lucide-react";
import { AppMessage } from "@/types/Enums";
import {
  Popover,
  PopoverAnchor,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";

export function App() {
  const [creds, setCreds] = useState({ swid: "", espnS2: "", leagueId: "" });
  const [open, setOpen] = useState(false);

  useEffect(() => {
    const load = async () => {
      const cookieData = await browser.runtime.sendMessage({
        type: AppMessage.FECTH_CREDENTIALS,
      });

      const leagueId = getLeagueIdFromUrl(window.location.href);

      setCreds({
        ...cookieData,
        leagueId,
      });
    };
    load();
  }, []);

  return (
    <div className="fixed bottom-6 left-6 z-9999">
      <Popover open={open} onOpenChange={setOpen}>
        <PopoverAnchor asChild>
          <Button
            className="size-12 rounded-full shadow-2xl p-2"
            onClick={(e) => {
              e.stopPropagation();
              setOpen((prev) => !prev);
            }}
          >
            <IdCard className="size-6" />
          </Button>
        </PopoverAnchor>
        <PopoverContent
          side="top"
          align="start"
          sideOffset={12}
          className="w-80 p-0 shadow-2xl border-2 border-primary/20 bg-white"
          onInteractOutside={(e) => {
            const path = e.detail.originalEvent.composedPath();
            const isClickOnButton = path.some(
              (el) => el instanceof HTMLElement && el.closest("button"),
            );

            if (isClickOnButton) {
              e.preventDefault();
            } else {
              setOpen(false);
            }
          }}
        >
          <Card className="border-0 shadow-none">
            <CardHeader className="flex flex-row items-center pt-2">
              <CardTitle className="font-bold flex items-center gap-3">
                <img
                  src={browser.runtime.getURL("/logo.png")}
                  className="w-12"
                  alt="HOF"
                />
                <span>ESPN Credentials</span>
              </CardTitle>
            </CardHeader>
            <CardContent className="space-y-4 pb-4">
              <DataRow label="League ID" value={creds.leagueId} />
              <DataRow label="SWID" value={creds.swid} />
              <DataRow label="ESPN S2" value={creds.espnS2} />
            </CardContent>
          </Card>
        </PopoverContent>
      </Popover>
    </div>
  );
}

function DataRow({
  label,
  value,
}: {
  label: string;
  value: string | undefined;
}) {
  const [copied, setCopied] = useState(false);

  const isDisabled = !value;

  const handleCopy = () => {
    navigator.clipboard.writeText(value ?? "");
    setCopied(true);
    setTimeout(() => setCopied(false), 2000);
  };

  return (
    <div className={cn("flex flex-col gap-1", isDisabled && "opacity-70")}>
      <span className="text-[10px] font-bold uppercase tracking-widest text-muted-foreground/80 px-1">
        {label}
      </span>
      <div
        onClick={handleCopy}
        className={cn(
          "group relative flex items-center justify-between rounded-md border p-2 transition-all duration-200",
          isDisabled ? "cursor-not-allowed " : "cursor-pointer",
          !isDisabled &&
            !copied &&
            "hover:bg-emerald-50/50 hover:border-primary/30",
          !isDisabled &&
            copied &&
            "border-emerald-500 bg-emerald-50/50 shadow-inner",
        )}
      >
        <code
          className={cn(
            "text-[11px] font-mono font-medium truncate pr-6",
            isDisabled ? "text-muted-foreground" : "text-foreground/80",
          )}
        >
          {value || "Not found. Navigate to your league."}
        </code>

        <div className="flex items-center gap-2">
          {isDisabled ? (
            // Hide icon or show a "locked" state if disabled
            <div className="size-3.5" />
          ) : copied ? (
            <span className="text-[9px] font-bold text-emerald-600 animate-in fade-in zoom-in-95">
              COPIED
            </span>
          ) : (
            <Copy className="size-3.5 text-muted-foreground/50 group-hover:text-primary transition-colors" />
          )}
        </div>
      </div>
    </div>
  );
}
