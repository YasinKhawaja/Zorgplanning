import http from "./http-common";

const getAll = () => {
  return http.get("/teams");
};

const get = (id) => {
  return http.get(`/teams/${id}`);
};

const create = (data) => {
  return http.post("/teams", data);
};

const update = (id, data) => {
  return http.put(`/teams/${id}`, data);
};

const remove = (id) => {
  return http.delete(`/teams/${id}`);
};

const TeamService = {
  getAll,
  get,
  create,
  update,
  remove,
};

export default TeamService;
