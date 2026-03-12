import { loadEvents } from "./controllers/eventController.js";

document.addEventListener("DOMContentLoaded", () => {
  if (document.getElementById("eventContainer")) {
    loadEvents();
  }
});