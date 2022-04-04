import AddIcon from "@mui/icons-material/Add";
import {
  Box,
  Button,
  Dialog as MuiDialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
} from "@mui/material";
import React from "react";
import Controls from "../../components/controls/Controls";
import Dialog from "../../components/presentations/Dialog";
import Notification from "../../components/presentations/Notification";
import TeamService from "../../services/TeamService";
import TeamForm from "./TeamForm";
import TeamsList from "./TeamsList";

const useStyles = () => ({
  btnAddDiv: { marginTop: "24px", textAlign: "center" },
});

export default function Teams(props) {
  //#region STATES
  const [openAddOrEditDialog, setOpenAddOrEditDialog] = React.useState(false);
  const [openDeleteDialog, setOpenDeleteDialog] = React.useState(false);
  const [teamToEdit, setTeamToEdit] = React.useState(null);
  const [apiErrors, setApiErrors] = React.useState(null);
  const [notify, setNotify] = React.useState({
    open: false,
    message: "",
    severity: "info",
  });
  //#endregion

  //#region VARIABLES
  const successNotification = (message) => ({
    open: true,
    message: message,
    severity: "success",
  });
  //#endregion

  const handleClickOpen = () => {
    setOpenAddOrEditDialog({ open: true, team: null });
  };

  const handleClickClose = (bool) => {
    setOpenAddOrEditDialog(Boolean(bool));
    setApiErrors(null);
  };

  const handleAddOrEdit = (team, resetFormFn) => {
    const data = JSON.stringify(team);
    if (team.id === 0) {
      TeamService.create(data)
        .then(() => {
          setOpenAddOrEditDialog(false);
          resetFormFn();
          setApiErrors(null);
          props.onRefresh();
          setNotify(successNotification("Added Succesfully"));
        })
        .catch((error) => {
          setApiErrors(
            error.response.data.responseException.exceptionMessage.errors
          );
        });
    } else {
      TeamService.update(team.id, data)
        .then(() => {
          setOpenAddOrEditDialog(false);
          resetFormFn();
          props.onRefresh();
          setNotify(successNotification("Edited Succesfully"));
        })
        .catch((error) => {
          setApiErrors(
            error.response.data.responseException.exceptionMessage.errors
          );
        });
    }
  };

  const handleDelete = (id) => {
    TeamService.remove(id)
      .then(() => {
        setOpenDeleteDialog(false);
        setTeamToEdit(null);
        props.onRefresh();
        setNotify(successNotification("Deleted Succesfully"));
      })
      .catch((error) => {
        console.error(error);
      });
  };

  //#region Hooks
  const classes = useStyles();
  //#endregion

  return (
    <>
      <TeamsList
        teams={props.teams}
        onSetTeamToEdit={setTeamToEdit}
        onOpenAddOrEditDialog={setOpenAddOrEditDialog}
        onOpenDeleteDialog={setOpenDeleteDialog}
      />
      <Box sx={classes.btnAddDiv}>
        <Controls.Button
          text="ADD"
          startIcon={<AddIcon />}
          onClick={handleClickOpen}
        ></Controls.Button>
      </Box>
      {/* TEAM ADD & EDIT */}
      <Dialog
        sx={{
          "& .css-1fu2e3p-MuiPaper-root-MuiDialog-paper": {
            minWidth: "500px",
          },
        }}
        title={
          teamToEdit == null
            ? "Add Team"
            : `Edit Team <strong>${teamToEdit && teamToEdit.name}</strong>`
        }
        openDialog={openAddOrEditDialog}
        setOpenDialog={handleClickClose}
      >
        <TeamForm
          onAddOrEdit={handleAddOrEdit}
          teamToEdit={teamToEdit}
          apiErrors={apiErrors}
        />
      </Dialog>
      {/* TEAM DELETE */}
      <MuiDialog
        open={openDeleteDialog}
        onClose={() => setOpenDeleteDialog(false)}
      >
        <DialogTitle>
          Are you sure you want to delete team{" "}
          <strong>{teamToEdit && teamToEdit.name}</strong>?
        </DialogTitle>
        <DialogContent>
          <DialogContentText>
            This action <strong>cannot</strong> be undone.
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setOpenDeleteDialog(false)} autoFocus>
            CANCEL
          </Button>
          <Button color="error" onClick={() => handleDelete(teamToEdit.id)}>
            DELETE
          </Button>
        </DialogActions>
      </MuiDialog>
      <Notification notify={notify} setNotify={setNotify} />
    </>
  );
}
