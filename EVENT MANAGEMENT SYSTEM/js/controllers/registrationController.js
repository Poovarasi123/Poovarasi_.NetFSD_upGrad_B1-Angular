import { addRegistration } from "../services/registrationService.js";
import { getEventById, updateEvent } from "../services/eventService.js";
import Registration from "../models/Registration.js";
import Event from "../models/Event.js";

export const handleRegistration = async (formData) => {
  try {
    // Create registration object
    const registration = new Registration(formData);
    registration.validate();

    // Fetch event
    const eventData = await getEventById(formData.eventId);
    const event = new Event(eventData);

    // Check seats
    event.reduceSeat();

    // Update event seats
    await updateEvent(event.id, { ...event });

    // Save registration
    await addRegistration(registration);

    alert("Registration successful!");
    window.location.href = "index.html";

  } catch (error) {
    alert(error.message);
  }
};