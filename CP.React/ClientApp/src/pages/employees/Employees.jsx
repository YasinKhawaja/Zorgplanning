import AddIcon from "@mui/icons-material/Add";
import CalendarMonthIcon from "@mui/icons-material/CalendarMonth";
import CancelIcon from "@mui/icons-material/Cancel";
import CheckBoxIcon from "@mui/icons-material/CheckBox";
import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import {
  Box,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  Grid,
  IconButton,
  Skeleton,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableRow,
} from "@mui/material";
import React from "react";
import Controls from "../../components/controls/Controls";
import { SuccessSnackbar } from "../../components/presentations/Snackbars";
import { useTable } from "../../hooks/useTable";
import EmployeeService from "../../services/EmployeeService";
import EmployeeForm from "./EmployeeForm";

const useStyles = () => ({
  toolbar: {
    ["@media (min-width:600px)"]: { padding: "0px" },
  },
  btnAddDiv: { marginBottom: "24px" },
});

const headers = [
  { id: "fullName", label: "Zorgkundige" },
  { id: "regimeId", label: "Regime" },
  { id: "isFixedNight", label: "Vaste Nacht" },
  { id: "actions", label: "Acties", disableSorting: true },
];

export default function Employees(props) {
  const { team } = props;

  const [employees, setEmployees] = React.useState(null);
  const [employeeToEdit, setEmployeeToEdit] = React.useState(null);
  const [openAddEditDialog, setOpenAddEditDialog] = React.useState(false);
  const [openDeleteDialog, setOpenDeleteDialog] = React.useState(false);
  const [apiErrors, setApiErrors] = React.useState(null);
  const [snackbar, setSnackbar] = React.useState({
    open: false,
    message: "",
  });

  React.useEffect(() => {
    fetchEmployees();
  }, []);

  React.useEffect(() => {
    if (!openAddEditDialog) {
      setApiErrors(null);
    }
  }, [openAddEditDialog]);

  const fetchEmployees = () => {
    EmployeeService.getAll(team.id)
      .then((response) => {
        setEmployees(response.data.result);
      })
      .catch((error) => {
        console.error(error);
      });
  };

  const { TableHeader } = useTable(headers, employees);

  const classes = useStyles();

  const handleAddOrEdit = (employee, resetForm) => {
    const employeeToJson = { ...employee, teamId: team.id };
    const data = JSON.stringify(employeeToJson);
    if (employee.id === 0) {
      EmployeeService.create(data)
        .then(() => {
          resetForm();
          setEmployeeToEdit(null);
          setOpenAddEditDialog(false);
          fetchEmployees();
          setSnackbar({
            ...snackbar,
            open: true,
            message: "Zorgkundige succesvol toegevoegd",
          });
        })
        .catch((error) => {
          setApiErrors(error.response.data.errors);
          setEmployeeToEdit(null);
          setOpenAddEditDialog(true);
        });
    } else {
      EmployeeService.update(employee.id, data)
        .then(() => {
          resetForm();
          setEmployeeToEdit(null);
          setOpenAddEditDialog(false);
          fetchEmployees();
          setSnackbar({
            ...snackbar,
            open: true,
            message: "Zorgkundige succesvol bijgewerkt",
          });
        })
        .catch((error) => {
          setApiErrors(error.response.data.errors);
          setEmployeeToEdit(null);
          setOpenAddEditDialog(true);
        });
    }
  };

  const handleDelete = (id) => {
    EmployeeService.remove(id)
      .then(() => {
        setOpenDeleteDialog(false);
        fetchEmployees();
        setSnackbar({
          ...snackbar,
          open: true,
          message: "Zorgkundige succesvol verwijderd",
        });
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const handleClickAdd = () => {
    setEmployeeToEdit(null);
    setOpenAddEditDialog(true);
  };

  const handleClickEdit = (employee) => {
    setEmployeeToEdit(employee);
    setOpenAddEditDialog(true);
  };

  const handleClickDelete = (employee) => {
    setEmployeeToEdit(employee);
    setOpenDeleteDialog(true);
  };

  const handleCloseSnackbar = () => {
    setSnackbar({ ...snackbar, open: false, message: "" });
  };

  return (
    <>
      {employees !== null ? (
        <>
          <Box sx={classes.btnAddDiv}>
            <EmployeeAddButton onClick={handleClickAdd} />
          </Box>
          <TableContainer>
            <Table className="table table-hover" sx={{ marginBottom: "0px" }}>
              <TableHeader />
              <EmployeesTableBody
                employees={employees}
                onClickEdit={handleClickEdit}
                onClickDelete={handleClickDelete}
              />
            </Table>
          </TableContainer>
          <EmployeeAddEditDialog
            open={openAddEditDialog}
            onClose={setOpenAddEditDialog}
            employeeToEdit={employeeToEdit}
            onAddOrEdit={handleAddOrEdit}
            apiErrors={apiErrors}
          />
          <EmployeeDeleteDialog
            open={openDeleteDialog}
            onClose={setOpenDeleteDialog}
            employeeToEdit={employeeToEdit}
            onDelete={handleDelete}
          />
        </>
      ) : (
        <EmployeesSkeleton />
      )}
      <SuccessSnackbar
        open={snackbar.open}
        onClose={handleCloseSnackbar}
        message={snackbar.message}
      />
    </>
  );
}

function EmployeeAddButton(props) {
  return (
    <Button
      variant="contained"
      startIcon={<AddIcon />}
      disableElevation
      onClick={props.onClick}
    >
      NIEUWE ZORGKUNDIGE
    </Button>
  );
}

function EmployeesSkeleton() {
  return (
    <Grid container spacing={2}>
      <Grid item xs={1.5}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={10.5}></Grid>
      <Grid item xs={12}>
        <Skeleton variant="rectangular" animation="wave" />
      </Grid>
      {[...Array(10)].map((e, i) => (
        <React.Fragment key={i}>
          <Grid item xs={3}>
            <Skeleton variant="rectangular" animation="wave" />
          </Grid>
          <Grid item xs={3}>
            <Skeleton variant="rectangular" animation="wave" />
          </Grid>
          <Grid item xs={3}>
            <Skeleton variant="rectangular" animation="wave" />
          </Grid>
          <Grid item xs={1}>
            <Skeleton variant="rectangular" animation="wave" />
          </Grid>
          <Grid item xs={1}>
            <Skeleton variant="rectangular" animation="wave" />
          </Grid>
          <Grid item xs={1}>
            <Skeleton variant="rectangular" animation="wave" />
          </Grid>
        </React.Fragment>
      ))}
    </Grid>
  );
}

function EmployeesTableBody(props) {
  return (
    <TableBody>
      {props.employees.map((employee) => (
        <TableRow key={employee.id}>
          <TableCell sx={{ textAlign: "center" }}>
            {employee.firstName} {employee.lastName}
          </TableCell>
          <TableCell sx={{ textAlign: "center" }}>
            {employee.regimeName}
          </TableCell>
          <TableCell sx={{ textAlign: "center" }}>
            {Boolean(employee.isFixedNight) ? (
              <CheckBoxIcon color="success" />
            ) : (
              <CancelIcon color="error" />
            )}
          </TableCell>
          <TableCell sx={{ textAlign: "center" }}>
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
                onClick={() => props.onClickEdit(employee)}
              />
            </Controls.ActionButton>
            <IconButton
              color="error"
              onClick={() => props.onClickDelete(employee)}
            >
              <DeleteIcon />
            </IconButton>
          </TableCell>
        </TableRow>
      ))}
    </TableBody>
  );
}

function EmployeeAddEditDialog(props) {
  return (
    <Dialog
      open={props.open}
      onClose={() => props.onClose(false)}
      fullWidth
      maxWidth="sm"
    >
      <DialogTitle>
        {props.employeeToEdit === null
          ? "Voeg een nieuwe zorgkundige toe"
          : 'Bewerk zorgkundige "' +
            props.employeeToEdit.firstName +
            " " +
            props.employeeToEdit.lastName +
            '"'}
      </DialogTitle>
      <DialogContent>
        <EmployeeForm
          employeeToEdit={props.employeeToEdit}
          onAddOrEdit={props.onAddOrEdit}
          apiErrors={props.apiErrors}
          onClose={props.onClose}
        />
      </DialogContent>
    </Dialog>
  );
}

function EmployeeDeleteDialog(props) {
  return (
    <Dialog open={props.open} onClose={() => props.onClose(false)}>
      <DialogTitle>
        Weet je zeker dat je zorgkundige "
        {props.employeeToEdit &&
          props.employeeToEdit.firstName + " " + props.employeeToEdit.firstName}
        " wilt verwijderen?
      </DialogTitle>
      <DialogContent>
        <DialogContentText>
          Deze actie kan <strong>niet</strong> ongedaan gemaakt worden.
        </DialogContentText>
      </DialogContent>
      <DialogActions>
        <Button onClick={() => props.onClose(false)}>ANNULEREN</Button>
        <Button
          color="error"
          onClick={() => props.onDelete(props.employeeToEdit.id)}
        >
          VERWIJDEREN
        </Button>
      </DialogActions>
    </Dialog>
  );
}
