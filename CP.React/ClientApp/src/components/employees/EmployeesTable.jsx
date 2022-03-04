import * as Mat from "@mui/material/";

export default function EmployeesTable(props) {
  const { employees } = props;
  console.log(employees);
  return (
    <Mat.TableContainer component={Mat.Paper}>
      <Mat.Table sx={{ minWidth: 650 }} aria-label="simple table">
        <Mat.TableHead>
          <Mat.TableRow>
            <Mat.TableCell>Full Name</Mat.TableCell>
            <Mat.TableCell align="center">Regime</Mat.TableCell>
            <Mat.TableCell align="center">Gender</Mat.TableCell>
            <Mat.TableCell align="center">Date of Birth</Mat.TableCell>
            <Mat.TableCell align="center">Town</Mat.TableCell>
            <Mat.TableCell align="center">Is Fixed Night</Mat.TableCell>
          </Mat.TableRow>
        </Mat.TableHead>
        <Mat.TableBody>
          {employees.map((employee) => (
            <Mat.TableRow
              key={employee.id}
              sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
            >
              <Mat.TableCell component="th" scope="employee">
                {`${employee.firstName} ${employee.lastName}`}
              </Mat.TableCell>
              <Mat.TableCell align="center">{employee.regimeId}</Mat.TableCell>
              <Mat.TableCell align="center">{employee.gender}</Mat.TableCell>
              <Mat.TableCell align="center">
                {employee.dateOfBirth}
              </Mat.TableCell>
              <Mat.TableCell align="center">{employee.town}</Mat.TableCell>
              <Mat.TableCell align="center">
                {employee.isFixedNight ? "Yes" : "No"}
              </Mat.TableCell>
            </Mat.TableRow>
          ))}
        </Mat.TableBody>
      </Mat.Table>
    </Mat.TableContainer>
  );
}
