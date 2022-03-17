import { Grid } from "@mui/material";
import React from "react";
import Controls from "../../components/controls/Controls";
import { Form, useForm } from "../../hooks/useForm";

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
  country: 0,
  isFixedNight: false,
  teamId: 0,
  regimeId: 0,
};

export default function EmployeeForm(props) {
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

  const { addOrEdit, employeeToEdit } = props;

  React.useEffect(() => {
    if (employeeToEdit != null) {
      setValues({ ...employeeToEdit });
    }
  }, [employeeToEdit]);

  const handleSubmit = (event) => {
    event.preventDefault();
    if (validate()) {
      addOrEdit(values, resetForm);
    }
  };

  return (
    <Form onSubmit={handleSubmit}>
      <Grid container>
        <Grid item xs={6}>
          {/* FIRST NAME */}
          <Controls.Input
            error={errors.firstName}
            label="First Name"
            name="firstName"
            onChange={handleInputChange}
            value={values.firstName}
          />
          {/* LAST NAME */}
          <Controls.Input
            error={errors.lastName}
            label="Last Name"
            name="lastName"
            onChange={handleInputChange}
            value={values.lastName}
          />
          {/* DATE OF BIRTH */}
          <Controls.DatePicker
            label="Date of Birth"
            name="dateOfBirth"
            onChange={handleInputChange}
            value={values.dateOfBirth}
          />
          {/* GENDER */}
          <Controls.RadioGroup
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
            label="ZIP Code"
            name="zipCode"
            onChange={handleInputChange}
            value={values.zipCode}
          />
          {/* TOWN */}
          <Controls.Input
            label="Town"
            name="town"
            onChange={handleInputChange}
            value={values.town}
          />
          {/* COUNTRY */}
          <Controls.Select
            label="Country"
            name="country"
            onChange={handleInputChange}
            options={[{ id: 1, name: "Belgium" }]}
            value={values.country}
          />
        </Grid>
        <Grid item xs={12}>
          {/* REGIME */}
          <Controls.Select
            error={errors.regimeId}
            label="Regime"
            name="regimeId"
            onChange={handleInputChange}
            options={[
              { id: 1, name: "Fulltime" },
              { id: 2, name: "Parttime" },
              { id: 3, name: "Halftime" },
            ]}
            value={values.regimeId}
          />
        </Grid>
        <div>
          <Controls.Button text="SUBMIT" type="submit" />
          <Controls.Button color="grey" text="RESET" onClick={resetForm} />
        </div>
      </Grid>
    </Form>
  );
}
