type Props = {
  children: React.ReactNode;
};

export function ProductPageFeatureHighlightGrid({ children }: Props) {
  return <div className="grid md:grid-cols-2 gap-8">{children}</div>;
}
