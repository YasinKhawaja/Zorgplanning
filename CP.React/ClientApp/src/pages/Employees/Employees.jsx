import AddIcon from "@mui/icons-material/Add";
import CalendarMonthIcon from "@mui/icons-material/CalendarMonth";
import CancelIcon from "@mui/icons-material/Cancel";
import CheckBoxIcon from "@mui/icons-material/CheckBox";
import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import { Button, TableBody, TableCell, TableRow, Toolbar } from "@mui/material";
import React from "react";
import Controls from "../../components/controls/Controls";
import ConfirmDialog from "../../components/presentations/ConfirmDialog";
import Dialog from "../../components/presentations/Dialog";
import Notification from "../../components/presentations/Notification";
import { useTable } from "../../hooks/useTable";
import EmployeeService from "../../services/EmployeeService";
import EmployeeForm from "./EmployeeForm";
const useStyles = () => ({
  toolbar: {
    ["@media (min-width:600px)"]: { padding: "0px" },
  },
});

const headers = [
  { id: "fullName", label: "Full Name" },
  { id: "regimeId", label: "Regime" },
  { id: "gender", label: "Gender" },
  { id: "dateOfBirth", label: "Date of Birth" },
  { id: "town", label: "Town" },
  { id: "isFixedNight", label: "Fixed Night" },
  { id: "actions", label: "Actions", disableSorting: true },
];

export default function Employees(props) {
  const { team } = props;

  //#region STATES
  const [employees, setEmployees] = React.useState([]);
  const [isPending, setIsPending] = React.useState(true);

  const [openDialog, setOpenDialog] = React.useState(false);
  const [employeeToEdit, setEmployeeToEdit] = React.useState(null);
  const [apiErrors, setApiErrors] = React.useState(null);

  const [confirmDialog, setConfirmDialog] = React.useState({
    open: false,
    title: "",
    subtitle: "",
  });
  const [notify, setNotify] = React.useState({
    open: false,
    message: "",
    severity: "info",
  });
  //#endregion

  const fetchEmployees = () => {
    EmployeeService.getAll(team.id)
      .then((response) => {
        setEmployees(response.data.result);
        setIsPending(false);
      })
      .catch((error) => {
        console.error(error);
      });
  };

  const refreshEmployees = () => {
    fetchEmployees();
  };

  //#region HOOKS
  React.useEffect(() => {
    fetchEmployees();
  }, [setEmployees]);

  const { TableContainer, TableHeader, TablePaginator } = useTable(
    headers,
    employees
  );

  const classes = useStyles();
  //#endregion

  const openInDialog = (employee) => {
    setEmployeeToEdit(employee);
    setOpenDialog(true);
  };

  const addOrEdit = (employee, resetForm) => {
    const employeeToJson = { ...employee, teamId: team.id };
    const data = JSON.stringify(employeeToJson);
    if (employee.id === 0) {
      EmployeeService.create(data)
        .then(() => {
          refreshEmployees();
          resetForm();
          setEmployeeToEdit(null);
          setOpenDialog(false);
          setNotify({
            open: true,
            message: "Added Successfully",
            severity: "success",
          });
        })
        .catch((error) => {
          setApiErrors(
            error.response.data.responseException.exceptionMessage.errors
          );
          setEmployeeToEdit(null);
          setOpenDialog(true);
        });
    } else {
      EmployeeService.update(employee.id, data)
        .then(() => {
          refreshEmployees();
          resetForm();
          setEmployeeToEdit(null);
          setOpenDialog(false);
          setNotify({
            open: true,
            message: "Updated Successfully",
            severity: "success",
          });
        })
        .catch((error) => {
          setApiErrors(
            error.response.data.responseException.exceptionMessage.errors
          );
          setEmployeeToEdit(null);
          setOpenDialog(true);
        });
    }
  };

  const handleDelete = (id) => {
    setConfirmDialog({ ...confirmDialog, open: false });
    EmployeeService.remove(id)
      .then(() => {
        refreshEmployees();
        setNotify({
          open: true,
          message: "Deleted Successfully",
          severity: "error",
        });
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <>
      <Toolbar sx={classes.toolbar}>
        <Controls.Button
          startIcon={<AddIcon />}
          text="ADD"
          onClick={() => {
            setOpenDialog(true);
            setEmployeeToEdit(null);
          }}
        />
      </Toolbar>
      <TableContainer>
        <TableHeader />
        {!isPending && (
          <TableBody>
            {employees.map((employee) => (
              <TableRow key={employee.id}>
                <TableCell>
                  {employee.firstName} {employee.lastName}
                </TableCell>
                <TableCell>{employee.regimeId}</TableCell>
                <TableCell>{employee.gender}</TableCell>
                <TableCell>{employee.dateOfBirth}</TableCell>
                <TableCell>{employee.town}</TableCell>
                <TableCell>
                  {Boolean(employee.isFixedNight) ? (
                    <CheckBoxIcon color="success" />
                  ) : (
                    <CancelIcon color="error" />
                  )}
                </TableCell>
                <TableCell>
                  <Button
                    sx={{
                      backgroundColor: "#90EE90",
                      margin: "4px",
                      minWidth: 0,
                      "& .MuiSvgIcon-root": { color: "#008000" },
                    }}
                    href={`teams/${employee.teamId}/employees/${employee.id}/calendar`}
                  >
                    <CalendarMonthIcon fontSize="small" />
                  </Button>
                  <Controls.ActionButton color="primary">
                    <EditIcon
                      fontSize="small"
                      onClick={() => openInDialog(employee)}
                    />
                  </Controls.ActionButton>
                  <Controls.ActionButton color="secondary">
                    <DeleteIcon
                      fontSize="small"
                      onClick={() =>
                        setConfirmDialog({
                          open: true,
                          title: `Are you sure you want to delete nurse <strong>${employee.firstName}</strong>?`,
                          subtitle:
                            "This action <strong>cannot</strong> be undone.",
                          onConfirm: () => {
                            handleDelete(employee.id);
                          },
                        })
                      }
                    />
                  </Controls.ActionButton>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        )}
      </TableContainer>
      <TablePaginator />
      <Dialog
        title="New Employee Form"
        openDialog={openDialog}
        setOpenDialog={setOpenDialog}
      >
        <EmployeeForm
          addOrEdit={addOrEdit}
          employeeToEdit={employeeToEdit}
          apiErrors={apiErrors}
        />
      </Dialog>
      <Notification notify={notify} setNotify={setNotify} />
      <ConfirmDialog
        confirmDialog={confirmDialog}
        setConfirmDialog={setConfirmDialog}
      />
    </>
  );
}
