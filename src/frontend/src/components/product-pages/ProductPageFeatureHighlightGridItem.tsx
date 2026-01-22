type Props = {
  children: React.ReactNode;
};

type TextProps = {
  children: React.ReactNode;
};

export function ProductPageFeatureHighlightGridItem({ children }: Props) {
  return <div className="border-l-2 border-primary pl-6 py-2">{children}</div>;
}

function Header({ children }: TextProps) {
  return <h3 className="font-bold tracking-tight mb-2">{children}</h3>;
}

function Description({ children }: TextProps) {
  return <p className="text-sm text-muted-foreground">{children}</p>;
}

ProductPageFeatureHighlightGridItem.Header = Header;
ProductPageFeatureHighlightGridItem.Description = Description;
