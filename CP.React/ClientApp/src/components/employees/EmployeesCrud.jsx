import React from "react";
import EmployeeService from "../../services/EmployeeService";
import EmployeesTable from "./EmployeesTable";
import { useParams } from "react-router-dom";

export default function EmployeesCrud() {
  const [employees, setEmployees] = React.useState([]);
  const { teamId } = useParams();

  const employeesRef = React.useRef();
  employeesRef.current = employees;

  React.useEffect(() => {
    fetchEmployees();
  }, []);

  const fetchEmployees = () => {
    EmployeeService.getAll(teamId)
      .then((response) => {
        setEmployees(response.data.result);
      })
      .catch((error) => {
        console.error(error);
      });
  };

  const refreshEmployeesTable = () => {
    fetchEmployees();
  };

  const handleEdit = () => {
    // Logic
    refreshEmployeesTable();
  };

  const handleDelete = (id) => {
    // Logic
    console.log(id);
    refreshEmployeesTable();
  };

  return <EmployeesTable employees={employees} onDelete={handleDelete} />;
}
