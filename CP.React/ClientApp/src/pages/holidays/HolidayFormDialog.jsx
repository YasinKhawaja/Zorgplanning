import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import * as React from "react";
import HolidayForm from "./HolidayForm";

export default function HolidayFormDialog(props) {
  const { open, onClose } = props;

  return (
    <Dialog open={open} onClose={() => onClose(false)} fullWidth maxWidth="sm">
      <DialogTitle>Add Holiday</DialogTitle>
      <DialogContent>
        <DialogContentText>
          Set the selected day as a holiday.
        </DialogContentText>
        <HolidayForm />
      </DialogContent>
      <DialogActions>
        <Button onClick={() => onClose(false)}>Cancel</Button>
        <Button onClick={() => onClose(false)}>Subscribe</Button>
      </DialogActions>
    </Dialog>
  );
}
