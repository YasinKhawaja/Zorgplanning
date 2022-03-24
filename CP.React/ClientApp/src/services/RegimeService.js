import http from "./http-common";

const getAll = () => {
  return http.get("/regimes");
};

const RegimeService = {
  getAll,
};

export default RegimeService;
