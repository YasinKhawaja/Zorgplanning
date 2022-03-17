import CheckIcon from "@mui/icons-material/Check";
import ClearIcon from "@mui/icons-material/Clear";
import EditIcon from "@mui/icons-material/Edit";
import {
  IconButton,
  Paper,
  styled,
  Table,
  TableBody,
  TableCell,
  tableCellClasses,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import EmployeeDelete from "./EmployeeDelete";

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.primary.main,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  "&:nth-of-type(odd)": {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}));

export default function EmployeesTable(props) {
  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }}>
        <TableHead>
          <TableRow>
            <StyledTableCell>Full Name</StyledTableCell>
            <StyledTableCell align="center">Regime</StyledTableCell>
            <StyledTableCell align="center">Gender</StyledTableCell>
            <StyledTableCell align="center">Age</StyledTableCell>
            <StyledTableCell align="center">Town</StyledTableCell>
            <StyledTableCell align="center">Fixed Night</StyledTableCell>
            <StyledTableCell align="center">Actions</StyledTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {props.employees.map((employee) => (
            <StyledTableRow
              key={employee.id}
              sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
            >
              <StyledTableCell component="th" scope="row">
                {employee.firstName + " " + employee.lastName}
              </StyledTableCell>
              <StyledTableCell align="center">
                {employee.regimeId}
              </StyledTableCell>
              <StyledTableCell align="center">
                {employee.gender}
              </StyledTableCell>
              <StyledTableCell align="center">
                {employee.dateOfBirth}
              </StyledTableCell>
              <StyledTableCell align="center">{employee.town}</StyledTableCell>
              {employee.isFixedNight ? (
                <StyledTableCell align="center">
                  <CheckIcon color="success" />
                </StyledTableCell>
              ) : (
                <StyledTableCell align="center">
                  <ClearIcon color="error" />
                </StyledTableCell>
              )}
              <StyledTableCell align="center">
                <IconButton>
                  <EditIcon color="success" />
                </IconButton>
                <EmployeeDelete employee={employee} onDelete={props.onDelete} />
              </StyledTableCell>
            </StyledTableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
