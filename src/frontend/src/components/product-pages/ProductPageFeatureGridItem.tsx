import { LucideIcon } from "lucide-react";

type Props = {
  icon: LucideIcon;
  children: React.ReactNode;
};

type HeaderProps = {
  children: React.ReactNode;
};

export function ProductPageFeatureGridItem({ icon: Icon, children }: Props) {
  return (
    <div className="space-y-4">
      <Icon className="size-8 text-primary/60" />
      {children}
    </div>
  );
}

function Header({ children }: HeaderProps) {
  return <h4 className="font-bold text-sm tracking-widest">{children}</h4>;
}

function Subheader({ children }: HeaderProps) {
  return (
    <p className="text-xs text-muted-foreground leading-relaxed">{children}</p>
  );
}

ProductPageFeatureGridItem.Header = Header;
ProductPageFeatureGridItem.Subheader = Subheader;
