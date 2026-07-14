function createVrThreeSessionSubjectiveForm() {
  const form = FormApp.create('Questionnaire subjectif VR - Trois sessions');
  form.setDescription(
    'Ce questionnaire est rempli une seule fois après les trois sessions VR. ' +
    'Seul l’identifiant participant nécessite une saisie. Toutes les autres réponses utilisent des échelles.'
  );
  form.setCollectEmail(false);
  form.setLimitOneResponsePerUser(false);
  form.setProgressBar(true);

  function addSection(title, helpText) {
    const item = form.addPageBreakItem().setTitle(title);
    if (helpText) item.setHelpText(helpText);
    return item;
  }

  function addGrid(title, rows, columns, required, helpText) {
    const item = form.addGridItem()
      .setTitle(title)
      .setRows(rows)
      .setColumns(columns)
      .setRequired(required);
    if (helpText) item.setHelpText(helpText);
    return item;
  }

  const tenPointColumns = [];
  for (let i = 0; i <= 10; i++) tenPointColumns.push(String(i));
  const agreeColumns = ['1', '2', '3', '4', '5'];
  const presenceColumns = ['1', '2', '3', '4', '5', '6', '7'];
  const symptomColumns = ['0', '1', '2', '3'];

  const workloadRows = [
    'Exigence mentale',
    'Exigence physique',
    'Pression temporelle',
    'Effort',
    'Frustration'
  ];

  const learningRows = [
    'J’ai clairement compris ce que je devais faire.',
    'Je me suis souvenu(e) du bon ordre de la procédure.',
    'Je me suis senti(e) confiant(e) pendant la tâche.',
    'Je me suis senti(e) capable de me corriger après une erreur.',
    'Je me suis senti(e) autonome pendant cette session.',
    'Cette session m’a aidé(e) à progresser.'
  ];

  const presenceRows = [
    'Je me suis senti(e) présent(e) dans le poste virtuel.',
    'L’environnement virtuel m’a semblé cohérent.',
    'Le poste d’étiquetage m’a semblé réaliste.',
    'Les interactions m’ont semblé naturelles.',
    'Je me suis senti(e) immergé(e) dans la tâche.'
  ];

  const comfortRows = [
    'Fatigue oculaire',
    'Vertiges',
    'Nausée',
    'Mal de tête',
    'Fatigue des mains ou des bras',
    'Inconfort général'
  ];

  const guidanceRows = [
    'Le guidage disponible était utile.',
    'Je savais quoi faire lorsque le guidage était limité ou absent.',
    'Je suis resté(e) calme pendant la session.',
    'Je me suis bien adapté(e) lorsque la situation devenait difficile.',
    'Je me suis senti(e) en contrôle de mes actions.',
    'La session m’a semblé stressante.'
  ];

  const overallRows = [
    'Utilité pour l’apprentissage',
    'Satisfaction vis-à-vis de cette session',
    'Motivation à continuer la formation VR'
  ];

  function addSessionQuestionnaire(sessionTitle, sessionHelp) {
    addSection(sessionTitle, sessionHelp);
    addGrid(
      sessionTitle + ' - Charge de travail',
      workloadRows,
      tenPointColumns,
      true,
      'Échelle adaptée NASA-TLX : 0 = très faible, 10 = très élevé.'
    );
    addGrid(
      sessionTitle + ' - Performance perçue',
      ['Performance perçue'],
      tenPointColumns,
      true,
      '0 = très mauvaise performance, 10 = excellente performance.'
    );
    addGrid(
      sessionTitle + ' - Apprentissage, confiance et autonomie',
      learningRows,
      agreeColumns,
      true,
      '1 = pas du tout d’accord, 5 = tout à fait d’accord.'
    );
    addGrid(
      sessionTitle + ' - Présence et réalisme',
      presenceRows,
      presenceColumns,
      true,
      '1 = pas du tout, 7 = complètement.'
    );
    addGrid(
      sessionTitle + ' - Confort et symptômes VR',
      comfortRows,
      symptomColumns,
      true,
      '0 = aucun, 1 = léger, 2 = modéré, 3 = sévère.'
    );
    addGrid(
      sessionTitle + ' - Guidage, stress et adaptation',
      guidanceRows,
      agreeColumns,
      true,
      '1 = pas du tout d’accord, 5 = tout à fait d’accord.'
    );
    addGrid(
      sessionTitle + ' - Évaluation globale',
      overallRows,
      agreeColumns,
      true,
      '1 = très faible, 5 = très élevé.'
    );
  }

  form.addTextItem()
    .setTitle('Identifiant participant')
    .setHelpText('Exemple : P01')
    .setRequired(true);

  addSessionQuestionnaire(
    'Session 1 - Guidée',
    'Répondez uniquement par rapport à la session 1, avec guidage visuel et audio.'
  );

  addSessionQuestionnaire(
    'Session 2 - Autonome',
    'Répondez uniquement par rapport à la session 2, sans guidage.'
  );

  addSessionQuestionnaire(
    'Session 3 - Test de stress',
    'Répondez uniquement par rapport à la session 3, avec événements inattendus ou difficulté supplémentaire.'
  );

  Logger.log('URL de modification : ' + form.getEditUrl());
  Logger.log('URL publiée : ' + form.getPublishedUrl());
}

