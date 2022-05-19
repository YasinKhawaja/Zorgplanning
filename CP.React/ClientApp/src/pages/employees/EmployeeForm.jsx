import { Button, DialogActions, Grid } from "@mui/material";
import parse from "html-react-parser";
import React from "react";
import Controls from "../../components/controls/Controls";
import { Form, useForm } from "../../hooks/useForm";
import RegimeService from "../../services/RegimeService";

const initialValues = {
  id: 0,
  firstName: "",
  lastName: "",
  isFixedNight: false,
  isActive: true,
  teamId: 0,
  regimeId: 0,
};

export default function EmployeeForm(props) {
  const { employeeToEdit } = props;

  const [regimes, setRegimes] = React.useState(null);
  const [isPending, setIsPending] = React.useState(true);

  React.useEffect(() => {
    RegimeService.getAll()
      .then((response) => {
        setRegimes(response.data.result);
        setIsPending(false);
      })
      .catch((error) => {
        console.error(error);
      });
    if (employeeToEdit != null) {
      setValues({ ...employeeToEdit });
    }
    if (props.apiErrors != null) {
      setErrors({ ...props.apiErrors });
    }
    console.log(props.apiErrors);
  }, [employeeToEdit, props.apiErrors]);

  const validate = (fieldValues = values) => {
    let tempErrors = { ...errors };
    if ("firstName" in fieldValues) {
      tempErrors.firstName = fieldValues.firstName
        ? ""
        : "First Name is required.";
    }
    if ("lastName" in fieldValues) {
      tempErrors.lastName = fieldValues.lastName
        ? ""
        : "Last Name is required.";
    }
    if ("regimeId" in fieldValues) {
      tempErrors.regimeId =
        fieldValues.regimeId !== 0 ? "" : "Regime is required.";
    }
    setErrors({ ...tempErrors });
    if (fieldValues === values) {
      return Object.values(tempErrors).every((x) => x === "");
    }
  };

  const { values, setValues, errors, setErrors, handleInputChange, resetForm } =
    useForm(initialValues, true, validate);

  const getErrors = (input) => {
    if (errors === null) return "";
    if (errors[input] === undefined) return "";
    let errorMsg = "";
    errors[input].map((error) => {
      errorMsg += `${error.toString()}<br />`;
    });
    return parse(errorMsg); // Parse to JSX
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    props.onAddOrEdit(values, resetForm);
  };

  return (
    <>
      {!isPending && (
        <Form onSubmit={handleSubmit}>
          <Grid container spacing={2} sx={{ marginBottom: "16px" }}>
            <Grid item xs={6}>
              {/* FIRST NAME */}
              <Controls.Input
                error={getErrors("FirstName")}
                label="Voornaam"
                name="firstName"
                onChange={handleInputChange}
                value={values.firstName}
              />
            </Grid>
            <Grid item xs={6}>
              {/* LAST NAME */}
              <Controls.Input
                error={getErrors("LastName")}
                label="Achternaam"
                name="lastName"
                onChange={handleInputChange}
                value={values.lastName}
              />
            </Grid>
            <Grid item xs={6}>
              {/* IS FIXED NIGHT */}
              <Controls.Checkbox
                label="Vaste Nacht"
                name="isFixedNight"
                onChange={handleInputChange}
                value={values.isFixedNight}
              />
            </Grid>
            <Grid item xs={6}>
              {/* REGIME */}
              <Controls.Select
                error={getErrors("RegimeId")}
                label="Regime"
                name="regimeId"
                onChange={handleInputChange}
                options={regimes}
                value={values.regimeId}
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
      )}
    </>
  );
}
