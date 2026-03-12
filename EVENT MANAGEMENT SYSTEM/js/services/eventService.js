const BASE_URL = "http://localhost:3000/events";

export const getEvents = async () => {
  const res = await fetch(BASE_URL);
  return res.json();
};

export const addEvent = async (event) => {
  const res = await fetch(BASE_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(event),
  });
  return res.json();
};

export const updateEvent = async (id, data) => {
  const res = await fetch(`${BASE_URL}/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  return res.json();
};

export const deleteEvent = async (id) => {
  await fetch(`${BASE_URL}/${id}`, { method: "DELETE" });
};
export const getEventById = async (id) => {
  const res = await fetch(`${BASE_URL}/${id}`);
  return res.json();
};