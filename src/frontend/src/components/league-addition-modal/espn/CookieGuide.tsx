import { useState } from "react";
import { Copy, Check } from "lucide-react";
import { Button } from "@/components/ui/button";
import { InstructionAccordion } from "../InstructionAccordion";
import { InstructionSet, InstructionStep } from "../InstructionSet";

export function CookieGuide() {
  const [copied, setCopied] = useState(false);

  const settingsUrl =
    "edge://settings/privacy/cookies/AllCookies/SiteCookiesDetails?siteCookiesDetails=espn.com";

  const handleCopy = () => {
    navigator.clipboard.writeText(settingsUrl);
    setCopied(true);
    setTimeout(() => setCopied(false), 2000);
  };

  const steps: InstructionStep[] = [
    {
      title: "Open Edge",
      description:
        "Edge has the most user friendly cookie experience. If you are unable to download edge, look up how to access cookie data for your browser.",
    },
    {
      title: `Copy the URL below`,
      description: "",
      additionalContent: (
        <div className="flex items-center mt-2 gap-2">
          <code className="flex-1 border rounded-sm px-2 py-1 text-xs break-all">
            {settingsUrl}
          </code>
          <Button
            size="icon"
            variant="outline"
            className="size-8 shrink-0"
            onClick={handleCopy}
            type="button"
          >
            {copied ? (
              <Check className="size-4 text-green-500" />
            ) : (
              <Copy className="size-4" />
            )}
          </Button>
        </div>
      ),
    },
    {
      title: "Paste in a new tab",
      description:
        "Paste that link into your address bar. It will take you directly to ESPN's data settings.",
    },
    {
      title: "Copy SWID & ESPN_S2",
      description:
        "Look for 'swid' and 'espn_s2'. Copy the text found in the 'Content' or 'Cookie Value' field.",
    },
  ];

  return (
    <InstructionAccordion title="Where do I find my SWID and ESPN S2?">
      <InstructionSet steps={steps} />
    </InstructionAccordion>
  );
}
