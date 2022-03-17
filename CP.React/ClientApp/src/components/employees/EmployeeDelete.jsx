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
  IconButton,
} from "@mui/material";
import * as React from "react";

export default function EmployeeDelete(props) {
  const [open, setOpen] = React.useState(false);
  const [isPending, setIsPending] = React.useState(false);

  const handleClick = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <>
      <EmployeeDeleteButton onClick={handleClick} />
      <EmployeeDeleteDialog
        open={open}
        isPending={isPending}
        employee={props.employee}
        onClose={handleClose}
        onDelete={() => props.onDelete(props.employee.id)}
      />
    </>
  );
}

function EmployeeDeleteButton(props) {
  return (
    <IconButton onClick={props.onClick}>
      <DeleteIcon color="error"></DeleteIcon>
    </IconButton>
  );
}

function EmployeeDeleteDialog(props) {
  return (
    <Dialog
      open={props.open}
      onClose={props.onClose}
      aria-labelledby="alert-dialog-title"
      aria-describedby="alert-dialog-description"
    >
      <DialogTitle id="alert-dialog-title">
        Are you sure you want to delete team{" "}
        <strong>{props.employee.firstName}</strong>?
      </DialogTitle>
      <DialogContent>
        <DialogContentText id="alert-dialog-description">
          This action <strong>cannot</strong> be undone.
        </DialogContentText>
      </DialogContent>
      <DialogActions>
        <Button onClick={props.onClose} autoFocus>
          CANCEL
        </Button>
        {props.isPending ? (
          <LoadingButton
            loading
            loadingPosition="start"
            startIcon={<SaveIcon />}
          >
            DELETE
          </LoadingButton>
        ) : (
          <Button onClick={props.onDelete} color="error">
            DELETE
          </Button>
        )}
      </DialogActions>
    </Dialog>
  );
}
