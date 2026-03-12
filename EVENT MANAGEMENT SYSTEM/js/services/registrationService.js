const BASE_URL = "http://localhost:3000/registrations";

export const getRegistrations = async () => {
  const res = await fetch(BASE_URL);
  return res.json();
};

export const addRegistration = async (registration) => {
  const res = await fetch(BASE_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(registration),
  });
  return res.json();
};

export const getRegistrationsByEvent = async (eventId) => {
  const res = await fetch(`${BASE_URL}?eventId=${eventId}`);
  return res.json();
};