import AddIcon from "@mui/icons-material/Add";
import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import SearchIcon from "@mui/icons-material/Search";
import {
  InputAdornment,
  TableBody,
  TableCell,
  TableRow,
  Toolbar,
} from "@mui/material";
import { makeStyles } from "@mui/styles";
import React from "react";
import Controls from "../../components/controls/Controls";
import Dialog from "../../components/Dialog";
import ConfirmDialog from "../../components/presentations/ConfirmDialog";
import Notification from "../../components/presentations/Notification";
import { useTable } from "../../hooks/useTable";
import EmployeeService from "../../services/EmployeeService";
import EmployeeForm from "./EmployeeForm";

const useStyles = makeStyles((theme) => ({
  toolbar: {
    padding: "0px",
  },
  searchInput: {
    width: "100%",
  },
  addButton: {
    position: "absolute",
    right: "10px",
  },
}));

const headers = [
  { id: "fullName", label: "Employee Name" },
  { id: "gender", label: "Gender" },
  { id: "town", label: "Town" },
  { id: "actions", label: "Actions", disableSorting: true },
];

export default function Employees() {
  //#region STATES
  const [confirmDialog, setConfirmDialog] = React.useState({
    open: false,
    title: "",
    subtitle: "",
  });
  const [notify, setNotify] = React.useState({
    open: false,
    message: "",
    severity: "",
  });
  //#endregion

  const [employees, setEmployees] = React.useState([]);
  React.useEffect(() => {
    EmployeeService.getAll(1)
      .then((response) => {
        setEmployees(response.data.result);
      })
      .catch((error) => {
        console.error(error);
      });
  }, [setEmployees]);

  const classes = useStyles();

  //#region FILTERING
  const [filterFn, setFilterFn] = React.useState({
    fn: (items) => {
      return items;
    },
  });

  const handleSearch = (event) => {
    let target = event.target;
    setFilterFn({
      fn: (items) => {
        if (target.value === "") {
          return items;
        } else {
          return items.filter(
            (x) =>
              x.firstName.toLowerCase().includes(target.value) &&
              x.lastName.toLowerCase().includes(target.value)
          );
        }
      },
    });
  };
  //#endregion

  const {
    TableContainer,
    TableHeader,
    TablePaginator,
    rowsAfterPagingAndSorting,
  } = useTable(headers, employees, filterFn);

  //#region DIALOG
  const [openDialog, setOpenDialog] = React.useState(false);
  //#endregion

  const [employeeToEdit, setEmployeeToEdit] = React.useState(null);

  const addOrEdit = (employee, resetForm) => {
    if (employee.id === 0) {
      // POST
    } else {
      // PUT
    }
    resetForm();
    setEmployeeToEdit(null);
    setOpenDialog(false);
    // REFRESH
    setNotify({
      open: true,
      message: "Saved Successfully",
      severity: "success",
    });
  };

  const openInDialog = (employee) => {
    setEmployeeToEdit(employee);
    setOpenDialog(true);
  };

  const handleDelete = (id) => {
    setConfirmDialog({ ...confirmDialog, open: false });
    //DELETE
    //REFRESH
    setNotify({
      open: true,
      message: "Deleted Successfully",
      severity: "error",
    });
  };

  return (
    <>
      <Toolbar className={classes.toolbar}>
        <Controls.Input
          className={classes.searchInput}
          label="Search Employees"
          InputProps={{
            startAdornment: (
              <InputAdornment position="start">
                <SearchIcon />
              </InputAdornment>
            ),
          }}
          onChange={handleSearch}
        />
        <Controls.Button
          className={classes.addButton}
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
        <TableBody>
          {rowsAfterPagingAndSorting().map((employee) => (
            <TableRow key={employee.id}>
              <TableCell>
                {employee.firstName} {employee.lastName}
              </TableCell>
              <TableCell>{employee.gender}</TableCell>
              <TableCell>{employee.town}</TableCell>
              <TableCell>
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
                        title: "Are you sure you want to delete this employee?",
                        subtitle: "This cannot be undone",
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
      </TableContainer>
      <TablePaginator />
      <Dialog
        title="New Employee Form"
        openDialog={openDialog}
        setOpenDialog={setOpenDialog}
      >
        <EmployeeForm addOrEdit={addOrEdit} employeeToEdit={employeeToEdit} />
      </Dialog>
      <Notification notify={notify} setNotify={setNotify} />
      <ConfirmDialog
        confirmDialog={confirmDialog}
        setConfirmDialog={setConfirmDialog}
      />
    </>
  );
}
