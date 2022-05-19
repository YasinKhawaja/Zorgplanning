import { Button, DialogActions, Grid } from "@mui/material";
import parse from "html-react-parser";
import React from "react";
import Controls from "../../components/controls/Controls";
import { Form, useForm } from "../../hooks/useForm";

const useStyles = () => ({
  buttonsWrap: {
    display: "flex",
    justifyContent: "space-between",
    marginTop: "16px",
  },
});

const types = [
  { id: "Leave", name: "Verlof" },
  { id: "Sickness", name: "Ziekte" },
  { id: "WorkingTimeReduction", name: "Arbeidsduurverkorting" },
];

const initialValues = {
  employeeId: 0,
  day: new Date(),
  type: "",
};

export default function AbsenceForm(props) {
  React.useEffect(() => {
    setErrors({ ...props.apiErrors });
  }, [props.apiErrors]);

  const { values, setValues, errors, setErrors, handleInputChange, resetForm } =
    useForm(initialValues, false);

  const classes = useStyles();

  const handleSubmit = (event) => {
    event.preventDefault();
    props.onAddOrEdit(values, resetForm);
  };

  const getErrors = (input) => {
    if (errors === null) return "";
    if (errors[input] === undefined) return "";
    let errorMsg = "";
    errors[input].map((error) => {
      errorMsg += `${error.toString()}<br />`;
    });
    return parse(errorMsg); // Parse to JSX
  };

  return (
    <Form onSubmit={handleSubmit}>
      <Grid container>
        <Grid item xs={12} sx={{ marginBottom: "16px" }}>
          {/* TYPE */}
          <Controls.Select
            error={getErrors("Type")}
            label="Type"
            name="type"
            onChange={handleInputChange}
            options={types}
            value={values.type}
          />
        </Grid>
      </Grid>
      <DialogActions sx={{ paddingTop: "0px", paddingBottom: "0px" }}>
        <Button onClick={() => props.onClose(false)}>Annuleren</Button>
        <Button type="submit" color="success">
          Opslaan
        </Button>
      </DialogActions>
    </Form>
  );
}
