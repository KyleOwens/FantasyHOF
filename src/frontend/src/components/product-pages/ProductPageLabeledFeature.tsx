import { LucideIcon } from "lucide-react";

type Props = {
  children: React.ReactNode;
};

type PrecursorProps = {
  icon: LucideIcon;
  title: string;
};

type TextProps = {
  children: React.ReactNode;
};

export function ProductPageLabeledFeature({ children }: Props) {
  return <div className="flex flex-col gap-y-4 mb-12">{children}</div>;
}

function Precusor({ icon: Icon, title }: PrecursorProps) {
  return (
    <div className="flex items-center gap-2 text-muted-foreground">
      <Icon className="size-6" />
      <span className="font-black tracking-widest text-sm">{title}</span>
    </div>
  );
}

function Header({ children }: TextProps) {
  return (
    <h2 className="text-4xl font-black tracking-tight uppercase">{children}</h2>
  );
}

function Description({ children }: TextProps) {
  return (
    <p className="text-muted-foreground leading-relaxed text-lg">{children}</p>
  );
}

ProductPageLabeledFeature.Precursor = Precusor;
ProductPageLabeledFeature.Header = Header;
ProductPageLabeledFeature.Description = Description;
