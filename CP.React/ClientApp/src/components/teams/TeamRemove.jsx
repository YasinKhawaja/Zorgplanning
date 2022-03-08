import SaveIcon from "@mui/icons-material/Save";
import LoadingButton from "@mui/lab/LoadingButton";
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  MenuItem,
} from "@mui/material";
import axios from "axios";
import * as React from "react";

export default function TeamRemove({ team }) {
  const [open, setOpen] = React.useState(false);
  const [isPending, setIsPending] = React.useState(false);

  const handleClick = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleDelete = async () => {
    setIsPending(true);
    try {
      await axios.delete(`api/teams/${team.id}`);
    } catch {}
  };

  return (
    <>
      <MenuItem onClick={handleClick}>Delete</MenuItem>
      <Dialog
        open={open}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">
          Are you sure you want to delete team <strong>{team.name}</strong>?
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            This action <strong>cannot</strong> be undone.
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} autoFocus>
            CANCEL
          </Button>
          {isPending ? (
            <LoadingButton
              loading
              loadingPosition="start"
              startIcon={<SaveIcon />}
            >
              DELETE
            </LoadingButton>
          ) : (
            <Button onClick={handleDelete} color="error">
              DELETE
            </Button>
          )}
        </DialogActions>
      </Dialog>
    </>
  );
}
