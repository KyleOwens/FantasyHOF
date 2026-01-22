type Props = {
  children: React.ReactNode;
};

export function ProductPageSection({ children }: Props) {
  return <section className="container mx-auto py-20 px-6">{children}</section>;
}
