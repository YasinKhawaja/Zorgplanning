import http from "./http-common";

const getAll = (teamId) => {
  return http.get(`/employees?team=${teamId}`);
};

const getAllAbsences = (id) => {
  return http.get(`/employees/${id}/absences`);
};

const get = (id) => {
  return http.get(`/employees/${id}`);
};

const create = (data) => {
  return http.post("/employees", data);
};

const createAbsence = (id, data) => {
  return http.post(`/employees/${id}/absences`, data);
};

const update = (id, data) => {
  return http.put(`/employees/${id}`, data);
};

const remove = (id) => {
  return http.delete(`/employees/${id}`);
};

const removeAbsence = (id, day) => {
  return http.delete(`/employees/${id}/absences?day=${day}`);
};

const EmployeeService = {
  getAll,
  getAllAbsences,
  get,
  create,
  createAbsence,
  update,
  remove,
  removeAbsence,
};

export default EmployeeService;
