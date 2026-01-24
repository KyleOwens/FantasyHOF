import { AppMessage } from "@/types/Enums";

export default defineBackground(() => {
  browser.runtime.onMessage.addListener((message, _, sendResponse) => {
    if (message.type !== AppMessage.FECTH_CREDENTIALS) return;

    const fetchCookies = async () => {
      try {
        const url = "https://www.espn.com";

        const [swid, s2] = await Promise.all([
          browser.cookies.get({ url, name: "SWID" }),
          browser.cookies.get({ url, name: "espn_s2" }),
        ]);

        sendResponse({
          swid: swid?.value ?? "Not found",
          espnS2: s2?.value ?? "Not found",
        });
      } catch (error) {
        sendResponse({ swid: "Error", espnS2: "Error" });
      }
    };

    fetchCookies();

    return true;
  });
});
