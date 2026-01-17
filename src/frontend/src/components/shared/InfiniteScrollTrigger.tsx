import { useEffect, useRef } from "react";
import { Spinner } from "../ui/spinner";

type Props = {
  onEndReached: () => void;
  isLoadingNext: boolean;
  hasNext: boolean;
  rootMargin?: string;
};

export function InfiniteScrollTrigger({
  onEndReached,
  isLoadingNext,
  hasNext,
  rootMargin = "200px",
}: Props) {
  const sentinelRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    if (isLoadingNext || !hasNext) return;

    const observer = new IntersectionObserver(
      (entries) => {
        if (!entries[0] || !entries[0].isIntersecting) return;

        onEndReached();
      },
      { rootMargin: rootMargin },
    );

    const sentinelDiv = sentinelRef.current;
    if (!sentinelDiv) return;

    observer.observe(sentinelDiv);

    return () => {
      if (sentinelDiv) {
        observer.unobserve(sentinelDiv);
      }
    };
  });

  return (
    <div ref={sentinelRef} className="w-full py-8 flex justify-center">
      {isLoadingNext && <Spinner className="size-12 text-primary" />}
      {!hasNext && (
        <p className="text-sm text-muted-foreground">No more records to show</p>
      )}
    </div>
  );
}
