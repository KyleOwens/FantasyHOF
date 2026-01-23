type Props = {
  children: React.ReactNode;
};

export function ProductPage({ children }: Props) {
  return (
    <div className="flex flex-col min-h-screen px-4 max-w-6xl mx-auto divide-y divide-slate-300">
      {children}
    </div>
  );
}
