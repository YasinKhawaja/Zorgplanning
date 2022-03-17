import { Alert, Snackbar } from "@mui/material";
import { makeStyles } from "@mui/styles";

const useStyles = makeStyles((theme) => ({
  root: { top: `${theme.spacing(10)} !important` },
}));

export default function Notification(props) {
  const { notify, setNotify } = props;
  const classes = useStyles();
  const handleClose = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }
    setNotify({ ...notify, open: false });
  };
  return (
    <Snackbar
      className={classes.root}
      open={notify.open}
      autoHideDuration={3000}
      anchorOrigin={{ vertical: "top", horizontal: "right" }}
      onClose={handleClose}
    >
      <Alert severity={notify.severity} onClose={handleClose}>
        {notify.message}
      </Alert>
    </Snackbar>
  );
}
