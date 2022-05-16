import { test } from "@playwright/test";

test("test", async ({ page }) => {
  // Go to https://localhost:44428/teams
  await page.goto("https://localhost:44428/teams");

  // Click html
  await Promise.all([
    page.waitForNavigation(/*{ url: 'https://localhost:44428/teams' }*/),
    page.locator("html").click(),
  ]);

  // Go to https://localhost:44428/teams
  await page.goto("https://localhost:44428/teams");

  // Click text=ADD
  await page.locator("text=ADD").click();

  // Click input[name="name"]
  await page.locator('input[name="name"]').click();

  // Fill input[name="name"]
  await page.locator('input[name="name"]').fill("Team Test A");

  // Click text=SUBMIT
  await page.locator("text=SUBMIT").click();
});
