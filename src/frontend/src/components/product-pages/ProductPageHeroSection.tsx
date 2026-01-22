type Props = {
  children: React.ReactNode;
};

type HeroHeaderProps = {
  children: React.ReactNode;
};

export function ProductPageHeroSection({ children }: Props) {
  return (
    <section className="py-24 relative">
      <div className="container mx-auto">
        <div className="flex flex-col items-center text-center space-y-8">
          {children}
        </div>
      </div>
    </section>
  );
}

function Header({ children }: HeroHeaderProps) {
  return (
    <h1 className="text-6xl md:text-8xl font-black tracking-tighter uppercase">
      {children}
    </h1>
  );
}

function Subheader({ children }: HeroHeaderProps) {
  return (
    <p className="text-lg md:text-2xl text-muted-foreground leading-relaxed">
      {children}
    </p>
  );
}

ProductPageHeroSection.Header = Header;
ProductPageHeroSection.Subheader = Subheader;
