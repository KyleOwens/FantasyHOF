type Props = {
  children: React.ReactNode;
};

export function ProductPageFeatureGrid({ children }: Props) {
  return (
    <div className="grid grid-cols-1 md:grid-cols-3 gap-12">{children}</div>
  );
}
