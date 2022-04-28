import http from "./http-common";

const getAllHolidays = () => {
  return http.get(`/dates/holidays`);
};

const DateService = {
  getAllHolidays,
};

export default DateService;
