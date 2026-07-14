# ICINCO LaTeX Draft Manifest

## Main Files

- `paper.tex` - main SCITEPRESS/ICINCO manuscript draft.
- `paper.bib` - bibliography.
- `SCITEPRESS.sty`, `article.cls`, `apalike.sty`, `apalike.bst` - required template files copied from the provided ICINCO example.
- `figures/` - figure files referenced by `paper.tex`.
- `section_guidance.md` - non-submission note explaining the section strategy.

## Referenced Figures

- `figures/fig_environment_sequence.png`
- `figures/fig_session_learning_spaghetti.png`
- `figures/fig_condition_statistics.png`
- `figures/fig_step_session_heatmap.png`
- `figures/fig_subjective_session_multiples.png`
- `figures/fig_correlation_matrix.png`

## Compile Command

Use this sequence locally or in Overleaf:

```bash
pdflatex paper.tex
bibtex paper
pdflatex paper.tex
pdflatex paper.tex
```

## Submission Notes

- The current draft is anonymous for double-blind review.
- `camera_ready_author_block.tex` contains a non-anonymous author-block draft for later use.
- Do not submit `section_guidance.md`.
- Before final submission, remove unused extra images from `figures/` if you make a clean zip manually.
- After acceptance/camera-ready, replace anonymous author metadata and add acknowledgements/disclosures required by SCITEPRESS/INSTICC.
