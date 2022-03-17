import { Container } from "@mui/material";
import Title from "../presentations/Title";
import EmployeeForm from "../../pages/Employees/EmployeeForm";

export default function EmployeeCreateIndex() {
  return (
    <Container maxWidth="sm" sx={{ marginTop: 5, marginBottom: 5 }}>
      <Title
        primary="Create a New Employee"
        secondary="Please fill in the new Employee's details."
      />
      <EmployeeForm />
    </Container>
  );
}
