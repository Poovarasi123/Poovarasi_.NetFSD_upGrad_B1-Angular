import { getEvents, deleteEvent } from "../services/eventService.js";
import { getRegistrationsByEvent } from "../services/registrationService.js";

export const loadEvents = async () => {
  try {
    const events = await getEvents();
    const container = document.getElementById("eventContainer");

  container.innerHTML = events.map(event => `
<div class="card">

<h3>${event.title}</h3>
<p><b>Date:</b> ${event.date}</p>
<p><b>Location:</b> ${event.location}</p>
<p><b>Available Seats:</b> ${event.availableSeats}</p>

<a class="btn register" href="register.html?eventId=${event.id}">Register</a>
<button class="btn edit" onclick="editEvent(${event.id})">Edit</button>
<button class="btn delete" onclick="removeEvent(${event.id})">Delete</button>

</div>
`).join("");

  } catch (error) {
    alert(error.message);
  }
};

window.removeEvent = async (id) => {

  const registrations = await getRegistrationsByEvent(id);

  if (registrations.length > 0) {
    alert("Cannot delete event. Registrations exist!");
    return;
  }

  if (confirm("Are you sure you want to delete this event?")) {
    await deleteEvent(id);
    alert("Event deleted");
    location.reload();
  }

};

window.editEvent = (id) => {
  window.location.href = `add-event.html?id=${id}`;
};