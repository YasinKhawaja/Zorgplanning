import { TextField } from "@mui/material";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import { useState } from "react";

export default function TeamCreateUpdateForm(props) {
  const [isEdit, setIsEdit] = useState(false);
  const [team, setTeam] = useState({ id: 0, name: "" });

  if (props.isEdit) {
    setIsEdit(true);
    setTeam(props.team);
  }

  const handleClose = () => {
    props.onClose();
  };

  const handleChange = (event) => {
    const { name, value } = event.target;
    setTeam({ ...team, [name]: value });
  };

  const handleCreate = (team) => {
    props.onCreate(team);
  };

  return (
    <Dialog open={props.open} onClose={handleClose}>
      <DialogTitle sx={{ textAlign: "center" }}>
        {isEdit ? `Update Team ${team.name}` : "Create a New Team"}
      </DialogTitle>
      <DialogContent>
        <DialogContentText>
          Please enter a <strong>name</strong> for the new team.
        </DialogContentText>
        <TextField
          autoFocus
          margin="dense"
          id="name"
          label="Name"
          type="text"
          fullWidth
          variant="standard"
          required
          value={team.name}
          name="name"
          onChange={handleChange}
        />
      </DialogContent>
      <DialogActions>
        <Button onClick={handleClose}>Cancel</Button>
        {isEdit ? (
          <Button onClick={() => props.onUpdate(team)}>Save</Button>
        ) : (
          <Button onClick={() => handleCreate(team)}>Save</Button>
        )}
      </DialogActions>
    </Dialog>
  );
}
