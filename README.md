# 🏆 Fantasy HOF (Hall of Fame)

**The definitive record book for your fantasy leagues.** Fantasy HOF aggregates historical data from multiple fantasy providers (Sleeper, ESPN, Yahoo, and more) into a single, unified interface. It transforms raw league history into "all-time" records, allowing users to settle debates with data-driven bragging rights.

---

## 🛠️ Technical Architecture

This project prioritizes constructing a maintainable, scalable, highly iterable application, utilizing a modern GraphQL-centric stack to handle large-scale data ingestion and complex relational queries.

### 🏗️ Backend (C# / .NET)
Built using **Domain-Driven Design (DDD)** principles to ensure a clean separation of concerns and a maintainable core.

* **API:** [HotChocolate GraphQL](https://chillicream.com/docs/hotchocolate) server featuring a fully compliant **Relay Node implementation** for standardized global object identification.
* **Performance:** Optimized query execution using **DataLoaders** to solve the N+1 problem and **Bulk Inserts** for lightning-fast ingestion of historical league data.
* **Real-time:** Utilizes **GraphQL Subscriptions** for live updates during data processing.
* **Security & Data:** **EntityFramework** paired with **PostgreSQL**. Implements **Row-Level Security (RLS)** via credential passthrough for rock-solid data isolation between leagues.
* **Auth:** Secured via **Clerk JWT** authentication.
* **Background Tasks:** **Hangfire** manages resilient background jobs for syncing external provider data.

### 🎨 Frontend (TypeScript / React)
A highly responsive, type-safe UI focused on efficient data fetching and state management.

* **Data Fetching:** [Relay](https://relay.dev/) for industrial-grade GraphQL management. Leverages **Relay's normalized cache** and the Node spec for seamless **Infinite Scrolling** and refetching.
* **Routing & Forms:** **TanStack Router** for type-safe navigation and **TanStack Form** for robust client-side validation.
* **Styling:** **Tailwind CSS** for layout and **ShadCN UI** for accessible, polished components.

---

## 🚀 Key Features

- **Multi-Provider Aggregation:** Sync data from Sleeper, ESPN, and more.
- **All-Time Leaderboards:** View the highest scoring teams, best win percentages, and 80+ other records across multiple seasons.
- **Dynamic Filtering:** Filter records by season, manager, or specific league settings.

---
