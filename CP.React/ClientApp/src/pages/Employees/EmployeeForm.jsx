import { Grid } from "@mui/material";
import parse from "html-react-parser";
import React from "react";
import Controls from "../../components/controls/Controls";
import { Form, useForm } from "../../hooks/useForm";
import RegimeService from "../../services/RegimeService";

const useStyles = () => ({
  buttonsWrap: {
    display: "flex",
    justifyContent: "space-between",
  },
});

const genderItems = [
  { id: "M", title: "Male" },
  { id: "F", title: "Female" },
  { id: "O", title: "Other" },
];

const initialValues = {
  id: 0,
  firstName: "",
  lastName: "",
  dateOfBirth: new Date(),
  gender: "M",
  address1: "",
  address2: "",
  zipCode: "",
  town: "",
  country: "",
  isFixedNight: false,
  isActive: true,
  teamId: 0,
  regimeId: 0,
};

export default function EmployeeForm(props) {
  const { addOrEdit, employeeToEdit } = props;

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

  const classes = useStyles();

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
    addOrEdit(values, resetForm);
  };

  return (
    <>
      {!isPending && (
        <Form onSubmit={handleSubmit}>
          <Grid container>
            <Grid item xs={6}>
              {/* FIRST NAME */}
              <Controls.Input
                error={getErrors("FirstName")}
                label="First Name"
                name="firstName"
                onChange={handleInputChange}
                value={values.firstName}
              />
              {/* LAST NAME */}
              <Controls.Input
                error={getErrors("LastName")}
                label="Last Name"
                name="lastName"
                onChange={handleInputChange}
                value={values.lastName}
              />
              {/* DATE OF BIRTH */}
              <Controls.DatePicker
                error={getErrors("DateOfBirth")}
                label=""
                name="dateOfBirth"
                onChange={handleInputChange}
                value={values.dateOfBirth}
              />
              {/* GENDER */}
              <Controls.RadioGroup
                error={getErrors("Gender")}
                items={genderItems}
                label="Gender"
                name="gender"
                onChange={handleInputChange}
                value={values.gender}
              />
              {/* IS FIXED NIGHT */}
              <Controls.Checkbox
                label="Fixed Night"
                name="isFixedNight"
                onChange={handleInputChange}
                value={values.isFixedNight}
              />
            </Grid>
            <Grid item xs={6}>
              {/* ADDRESS 1 */}
              <Controls.Input
                error={getErrors("Address1")}
                label="Address 1"
                name="address1"
                onChange={handleInputChange}
                value={values.address1}
              />
              {/* ADDRESS 2 */}
              <Controls.Input
                label="Address 2"
                name="address2"
                onChange={handleInputChange}
                value={values.address2}
              />
              {/* ZIP CODE */}
              <Controls.Input
                error={getErrors("ZipCode")}
                label="ZIP Code"
                name="zipCode"
                onChange={handleInputChange}
                value={values.zipCode}
              />
              {/* TOWN */}
              <Controls.Input
                error={getErrors("Town")}
                label="Town"
                name="town"
                onChange={handleInputChange}
                value={values.town}
              />
              {/* COUNTRY */}
              <Controls.Select
                error={getErrors("Country")}
                label="Country"
                name="country"
                onChange={handleInputChange}
                options={[{ id: "Belgium", name: "Belgium" }]}
                value={values.country}
              />
            </Grid>
            <Grid item xs={12}>
              {/* REGIME */}
              <Controls.Select
                error={getErrors("Regime")}
                label="Regime"
                name="regimeId"
                onChange={handleInputChange}
                options={regimes}
                value={values.regimeId}
              />
            </Grid>
            <div style={classes.buttonsWrap}>
              <Controls.Button text="SUBMIT" type="submit" />
              <Controls.Button color="grey" text="RESET" onClick={resetForm} />
            </div>
          </Grid>
        </Form>
      )}
    </>
  );
}
