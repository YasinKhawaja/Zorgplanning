import DeleteIcon from "@mui/icons-material/Delete";
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
import * as React from "react";

export default function TeamDelete(props) {
  const [open, setOpen] = React.useState(false);
  const [isPending, setIsPending] = React.useState(false);

  const handleClick = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleSubmit = (id) => {
    setIsPending(true);
    props.onDelete(id);
  };

  return (
    <>
      <MenuItem onClick={handleClick}>
        <DeleteIcon color="error" fontSize="small" />
        Delete
      </MenuItem>
      <Dialog
        open={open}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">
          Are you sure you want to delete team{" "}
          <strong>{props.team.name}</strong>?
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
            <Button onClick={() => handleSubmit(props.team.id)} color="error">
              DELETE
            </Button>
          )}
        </DialogActions>
      </Dialog>
    </>
  );
}
