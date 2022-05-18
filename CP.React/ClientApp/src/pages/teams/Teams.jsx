import AddIcon from "@mui/icons-material/Add";
import {
  Box,
  Button,
  Dialog as MuiDialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  Grid,
  Skeleton,
} from "@mui/material";
import React from "react";
import TeamService from "../../services/TeamService";
import TeamForm from "./TeamForm";
import TeamsList from "./TeamsList";

const useStyles = () => ({
  btnAddDiv: { marginBottom: "24px" },
  progressWrap: { display: "flex", justifyContent: "center" },
});

export default function Teams() {
  const [teams, setTeams] = React.useState(null);
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
      })
      .catch((error) => {
        console.error(error);
      });
  };

  const handleClickOpen = () => {
    setTeamToEdit(null);
    setOpenAddOrEditDialog(true);
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
          setApiErrors(null);
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

  return teams !== null ? (
    <>
      <Box sx={classes.btnAddDiv}>
        <TeamAddButton onClick={handleClickOpen} />
      </Box>
      <TeamsList
        teams={teams}
        onSetTeamToEdit={setTeamToEdit}
        onOpenAddOrEditDialog={setOpenAddOrEditDialog}
        onOpenDeleteDialog={setOpenDeleteDialog}
      />
      <TeamAddEditDialog
        onClose={handleClickClose}
        open={openAddOrEditDialog}
        onAddOrEdit={handleAddOrEdit}
        teamToEdit={teamToEdit}
        apiErrors={apiErrors}
      />
      <TeamDeleteDialog
        teamToEdit={teamToEdit}
        open={openDeleteDialog}
        onClose={setOpenDeleteDialog}
        onDelete={handleDelete}
      />
    </>
  ) : (
    <TeamsSkeleton />
  );
}

function TeamsSkeleton() {
  return (
    <Grid container spacing={2}>
      <Grid item xs={1.5}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={10.5}></Grid>
      {[...Array(10)].map((e, i) => (
        <React.Fragment key={i}>
          <Grid item xs={11.5}>
            <Skeleton variant="rectangular" animation="wave" />
          </Grid>
          <Grid item xs={0.5}>
            <Skeleton variant="circular" animation="wave" />
          </Grid>
        </React.Fragment>
      ))}
    </Grid>
  );
}

function TeamAddButton(props) {
  return (
    <Button
      variant="contained"
      startIcon={<AddIcon />}
      disableElevation
      onClick={props.onClick}
    >
      NIEUW TEAM
    </Button>
  );
}

function TeamAddEditDialog(props) {
  return (
    <MuiDialog
      open={props.open}
      onClose={() => props.onClose(false)}
      fullWidth
      maxWidth="sm"
    >
      <DialogTitle>
        {props.teamToEdit === null
          ? "Maak een nieuw team aan"
          : 'Bewerk team "' + props.teamToEdit.name + '"'}
      </DialogTitle>
      <DialogContent>
        <TeamForm
          apiErrors={props.apiErrors}
          teamToEdit={props.teamToEdit}
          onAddOrEdit={props.onAddOrEdit}
          onClose={props.onClose}
        />
      </DialogContent>
    </MuiDialog>
  );
}

function TeamDeleteDialog(props) {
  return (
    <MuiDialog open={props.open} onClose={() => props.onClose(false)}>
      <DialogTitle>
        Weet je zeker dat je team "{props.teamToEdit && props.teamToEdit.name}"
        wilt verwijderen?
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
          onClick={() => props.onDelete(props.teamToEdit.id)}
        >
          VERWIJDEREN
        </Button>
      </DialogActions>
    </MuiDialog>
  );
}
