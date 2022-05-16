import AddIcon from "@mui/icons-material/Add";
import {
  Box,
  Button,
  CircularProgress,
  Dialog as MuiDialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
} from "@mui/material";
import React from "react";
import Controls from "../../components/controls/Controls";
import Dialog from "../../components/presentations/Dialog";
import TeamService from "../../services/TeamService";
import TeamForm from "./TeamForm";
import TeamsList from "./TeamsList";

const useStyles = () => ({
  btnAddDiv: { marginTop: "24px", textAlign: "center" },
  progressWrap: { display: "flex", justifyContent: "center" },
});

export default function Teams(props) {
  const [teams, setTeams] = React.useState(null);
  const [isPending, setIsPending] = React.useState(true);
  const [openAddOrEditDialog, setOpenAddOrEditDialog] = React.useState(false);
  const [openDeleteDialog, setOpenDeleteDialog] = React.useState(false);
  const [teamToEdit, setTeamToEdit] = React.useState(null);
  const [apiErrors, setApiErrors] = React.useState(null);

  React.useEffect(() => {
    fetchTeams();
  }, []);

  const classes = useStyles();

  const fetchTeams = () => {
    TeamService.getAll()
      .then((response) => {
        setTeams(response.data.result);
        setIsPending(false);
      })
      .catch((error) => {
        console.error(error);
      });
  };

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
          fetchTeams();
        })
        .catch((error) => {
          setApiErrors(error.response.data.errors);
        });
    } else {
      TeamService.update(team.id, data)
        .then(() => {
          setOpenAddOrEditDialog(false);
          resetFormFn();
          fetchTeams();
        })
        .catch((error) => {
          setApiErrors(error.response.data.errors);
        });
    }
  };

  const handleDelete = (id) => {
    TeamService.remove(id)
      .then(() => {
        setOpenDeleteDialog(false);
        setTeamToEdit(null);
        fetchTeams();
      })
      .catch((error) => {
        console.error(error);
      });
  };

  if (!isPending) {
    return (
      <>
        <TeamsList
          teams={teams}
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
      </>
    );
  } else {
    return (
      <Box sx={classes.progressWrap}>
        <CircularProgress />
      </Box>
    );
  }
}
