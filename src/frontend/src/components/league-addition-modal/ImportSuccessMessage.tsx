import { motion } from "framer-motion";
import { Check } from "lucide-react";

export function ImportSuccessMessage() {
  return (
    <motion.div
      className="flex flex-col items-center justify-center py-8"
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
    >
      <motion.div
        className="rounded-full bg-emerald-100 p-4 dark:bg-emerald-900/30"
        initial={{ scale: 0, opacity: 0 }}
        animate={{ scale: 1, opacity: 1 }}
        transition={{
          type: "spring",
          stiffness: 600,
          damping: 30,
          mass: 0.8,
        }}
      >
        <motion.div
          initial={{ scale: 0, rotate: -80 }}
          animate={{ scale: 1, rotate: 0 }}
          transition={{
            type: "spring",
            stiffness: 800,
            damping: 30,
            delay: 0.1,
          }}
        >
          <Check className="size-16 text-emerald-600 dark:text-emerald-400 stroke-[3px]" />
        </motion.div>
      </motion.div>

      <motion.div
        initial={{ opacity: 0, y: 10 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ delay: 0.2, duration: 0.3, ease: "easeOut" }}
        className="text-center"
      >
        <p className="mt-6 text-xl font-medium">League successfully added!</p>
        <p className="text-sm text-muted-foreground">
          Redirecting to your leagues page...
        </p>
      </motion.div>
    </motion.div>
  );
}
