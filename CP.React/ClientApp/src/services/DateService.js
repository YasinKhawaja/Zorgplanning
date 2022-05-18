import http from "./http-common";

const getAllHolidays = () => {
  return http.get("/dates/holidays");
};

const addHoliday = (data) => {
  return http.post("/dates/holidays", data);
};

const removeHoliday = (date) => {
  return http.delete(`/dates/holidays?date=${date}`);
};

const DateService = {
  getAllHolidays,
  addHoliday,
  removeHoliday,
};

export default DateService;
