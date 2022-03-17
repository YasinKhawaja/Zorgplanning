import EditIcon from "@mui/icons-material/Edit";
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  MenuItem,
  TextField,
} from "@mui/material";
import * as React from "react";
import TeamCrud from "./TeamCrud";

export default function TeamDelete(props) {
  const { team, onUpdate } = props;

  const [open, setOpen] = React.useState(false);

  const handleClick = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleChange = (event) => {
    const { name, value } = event.target;
    team = { ...team, [name]: value };
  };

  const handleUpdate = (id, team) => {
    onUpdate(id, team);
  };

  const handleSubmit = (id) => {
    handleUpdate(id, team);
  };

  return (
    <>
      <MenuItem onClick={handleClick}>
        <EditIcon color="success" fontSize="small" />
        Edit
      </MenuItem>
      <Dialog open={open} onClose={handleClose}>
        <DialogTitle sx={{ textAlign: "center" }}>
          Update Team <strong>{team.name}</strong>
        </DialogTitle>
        <DialogContent>
          <DialogContentText>
            Please enter a new <strong>name</strong> for the team.
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
          <Button onClick={() => handleSubmit(team.id)}>Save</Button>
        </DialogActions>
      </Dialog>
    </>
  );
}
