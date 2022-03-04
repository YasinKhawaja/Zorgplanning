import { Box, CircularProgress, Container } from "@mui/material";
import { useParams } from "react-router-dom";
import useFetch from "../../hooks/useFetch";
import EmployeesTable from "./EmployeesTable";

export default function EmployeesCrud() {
  const { teamId } = useParams();

  const {
    data: employees,
    isPending,
    error,
  } = useFetch(`api/employees?team=${teamId}&`);

  const content = () => {
    if (isPending) {
      return <CircularProgress />;
    }
    if (error !== null) {
      return <p>{error}</p>;
    }
    if (employees === null) {
      return (
        <p>There are currently no nurses in this team, consider adding one.</p>
      );
    } else {
      return <EmployeesTable employees={employees} />;
    }
  };

  return (
    <Container maxWidth="md">
      <Box sx={{ textAlign: "center", m: 5 }}>
        <h1>Nurses</h1>
      </Box>
      <Box sx={{ textAlign: "center" }}>{content()}</Box>
    </Container>
  );
}
