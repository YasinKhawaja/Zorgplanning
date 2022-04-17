import React from "react";

export default function Home() {
  return (
    <>
      <div className="px-4 pt-5 my-5 text-center border-bottom">
        <h1 className="display-4 fw-bold">Centered screenshot</h1>
        <div className="col-lg-6 mx-auto">
          <p className="lead mb-4">
            Quickly design and customize responsive mobile-first sites with
            Bootstrap, the world’s most popular front-end open source toolkit,
            featuring Sass variables and mixins, responsive grid system,
            extensive prebuilt components, and powerful JavaScript plugins.
          </p>
          <div className="d-grid gap-2 d-sm-flex justify-content-sm-center mb-5">
            <button
              type="button"
              className="btn btn-primary btn-lg px-4 me-sm-3"
            >
              Primary button
            </button>
            <button
              type="button"
              className="btn btn-outline-secondary btn-lg px-4"
            >
              Secondary
            </button>
          </div>
        </div>
        <div className="overflow-hidden" style={{ maxHeight: "30vh" }}>
          <div className="container px-5">
            <img
              src="https://getbootstrap.com/docs/5.1/assets/brand/bootstrap-social.png"
              className="img-fluid border rounded-3 shadow-lg mb-4"
              alt="Example image"
              loading="lazy"
              width="700"
              height="500"
            />
          </div>
        </div>
      </div>
      <footer
        className="container"
        style={{ marginTop: "48px", marginBottom: "48px" }}
      >
        <p className="float-end">
          <a href="#">Back to top</a>
        </p>
        <p>
          © 2017–2021 Company, Inc. · <a href="#">Privacy</a> ·{" "}
          <a href="#">Terms</a>
        </p>
      </footer>
    </>
  );
}
