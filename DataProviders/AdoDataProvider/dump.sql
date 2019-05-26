--
-- PostgreSQL database dump
--

-- Dumped from database version 11.2
-- Dumped by pg_dump version 11.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: Answers; Type: TABLE; Schema: public; Owner: quorum_user
--

CREATE TABLE public."Answers" (
    "Id" integer NOT NULL,
    "Content" text,
    "IsCorrect" boolean NOT NULL,
    "QuestionId" integer NOT NULL
);


ALTER TABLE public."Answers" OWNER TO quorum_user;

--
-- Name: Answers_Id_seq; Type: SEQUENCE; Schema: public; Owner: quorum_user
--

CREATE SEQUENCE public."Answers_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Answers_Id_seq" OWNER TO quorum_user;

--
-- Name: Answers_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: quorum_user
--

ALTER SEQUENCE public."Answers_Id_seq" OWNED BY public."Answers"."Id";


--
-- Name: ChallengedAnswers; Type: TABLE; Schema: public; Owner: quorum_user
--

CREATE TABLE public."ChallengedAnswers" (
    "Id" integer NOT NULL,
    "SourceAnswerId" integer NOT NULL,
    "IsUserCorrect" boolean NOT NULL,
    "ChallengedQuestionId" integer NOT NULL
);


ALTER TABLE public."ChallengedAnswers" OWNER TO quorum_user;

--
-- Name: ChallengedQuestions; Type: TABLE; Schema: public; Owner: quorum_user
--

CREATE TABLE public."ChallengedQuestions" (
    "Id" integer NOT NULL,
    "SourceQuestionId" integer NOT NULL,
    "TotalScore" integer NOT NULL,
    "UserScore" integer NOT NULL,
    "ChallengedTestId" integer NOT NULL
);


ALTER TABLE public."ChallengedQuestions" OWNER TO quorum_user;

--
-- Name: ChallengedTests; Type: TABLE; Schema: public; Owner: quorum_user
--

CREATE TABLE public."ChallengedTests" (
    "Id" integer NOT NULL,
    "SourceTestId" integer NOT NULL,
    "MaximumScore" integer NOT NULL,
    "UserScore" integer NOT NULL
);


ALTER TABLE public."ChallengedTests" OWNER TO quorum_user;

--
-- Name: PassedAnswers_Id_seq; Type: SEQUENCE; Schema: public; Owner: quorum_user
--

CREATE SEQUENCE public."PassedAnswers_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."PassedAnswers_Id_seq" OWNER TO quorum_user;

--
-- Name: PassedAnswers_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: quorum_user
--

ALTER SEQUENCE public."PassedAnswers_Id_seq" OWNED BY public."ChallengedAnswers"."Id";


--
-- Name: PassedQuestions_Id_seq; Type: SEQUENCE; Schema: public; Owner: quorum_user
--

CREATE SEQUENCE public."PassedQuestions_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."PassedQuestions_Id_seq" OWNER TO quorum_user;

--
-- Name: PassedQuestions_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: quorum_user
--

ALTER SEQUENCE public."PassedQuestions_Id_seq" OWNED BY public."ChallengedQuestions"."Id";


--
-- Name: PassedTests_Id_seq; Type: SEQUENCE; Schema: public; Owner: quorum_user
--

CREATE SEQUENCE public."PassedTests_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."PassedTests_Id_seq" OWNER TO quorum_user;

--
-- Name: PassedTests_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: quorum_user
--

ALTER SEQUENCE public."PassedTests_Id_seq" OWNED BY public."ChallengedTests"."Id";


--
-- Name: Questions; Type: TABLE; Schema: public; Owner: quorum_user
--

CREATE TABLE public."Questions" (
    "Id" integer NOT NULL,
    "Content" text,
    "TestId" integer NOT NULL
);


ALTER TABLE public."Questions" OWNER TO quorum_user;

--
-- Name: Questions_Id_seq; Type: SEQUENCE; Schema: public; Owner: quorum_user
--

CREATE SEQUENCE public."Questions_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Questions_Id_seq" OWNER TO quorum_user;

--
-- Name: Questions_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: quorum_user
--

ALTER SEQUENCE public."Questions_Id_seq" OWNED BY public."Questions"."Id";


--
-- Name: Tags; Type: TABLE; Schema: public; Owner: quorum_user
--

CREATE TABLE public."Tags" (
    "Id" integer NOT NULL,
    "Content" text,
    "TestId" integer NOT NULL
);


ALTER TABLE public."Tags" OWNER TO quorum_user;

--
-- Name: Tag_Id_seq; Type: SEQUENCE; Schema: public; Owner: quorum_user
--

CREATE SEQUENCE public."Tag_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Tag_Id_seq" OWNER TO quorum_user;

--
-- Name: Tag_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: quorum_user
--

ALTER SEQUENCE public."Tag_Id_seq" OWNED BY public."Tags"."Id";


--
-- Name: Tests; Type: TABLE; Schema: public; Owner: quorum_user
--

CREATE TABLE public."Tests" (
    "Id" integer NOT NULL,
    "Name" text,
    "Description" text
);


ALTER TABLE public."Tests" OWNER TO quorum_user;

--
-- Name: Tests_Id_seq; Type: SEQUENCE; Schema: public; Owner: quorum_user
--

CREATE SEQUENCE public."Tests_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Tests_Id_seq" OWNER TO quorum_user;

--
-- Name: Tests_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: quorum_user
--

ALTER SEQUENCE public."Tests_Id_seq" OWNED BY public."Tests"."Id";

--
-- Name: Answers Id; Type: DEFAULT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."Answers" ALTER COLUMN "Id" SET DEFAULT nextval('public."Answers_Id_seq"'::regclass);


--
-- Name: ChallengedAnswers Id; Type: DEFAULT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."ChallengedAnswers" ALTER COLUMN "Id" SET DEFAULT nextval('public."PassedAnswers_Id_seq"'::regclass);


--
-- Name: ChallengedQuestions Id; Type: DEFAULT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."ChallengedQuestions" ALTER COLUMN "Id" SET DEFAULT nextval('public."PassedQuestions_Id_seq"'::regclass);


--
-- Name: ChallengedTests Id; Type: DEFAULT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."ChallengedTests" ALTER COLUMN "Id" SET DEFAULT nextval('public."PassedTests_Id_seq"'::regclass);


--
-- Name: Questions Id; Type: DEFAULT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."Questions" ALTER COLUMN "Id" SET DEFAULT nextval('public."Questions_Id_seq"'::regclass);


--
-- Name: Tags Id; Type: DEFAULT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."Tags" ALTER COLUMN "Id" SET DEFAULT nextval('public."Tag_Id_seq"'::regclass);


--
-- Name: Tests Id; Type: DEFAULT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."Tests" ALTER COLUMN "Id" SET DEFAULT nextval('public."Tests_Id_seq"'::regclass);


--
-- Name: Answers PK_Answers; Type: CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."Answers"
    ADD CONSTRAINT "PK_Answers" PRIMARY KEY ("Id");


--
-- Name: ChallengedAnswers PK_ChallengedAnswers; Type: CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."ChallengedAnswers"
    ADD CONSTRAINT "PK_ChallengedAnswers" PRIMARY KEY ("Id");


--
-- Name: ChallengedQuestions PK_ChallengedQuestions; Type: CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."ChallengedQuestions"
    ADD CONSTRAINT "PK_ChallengedQuestions" PRIMARY KEY ("Id");


--
-- Name: ChallengedTests PK_ChallengedTests; Type: CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."ChallengedTests"
    ADD CONSTRAINT "PK_ChallengedTests" PRIMARY KEY ("Id");


--
-- Name: Questions PK_Questions; Type: CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."Questions"
    ADD CONSTRAINT "PK_Questions" PRIMARY KEY ("Id");


--
-- Name: Tags PK_Tags; Type: CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."Tags"
    ADD CONSTRAINT "PK_Tags" PRIMARY KEY ("Id");


--
-- Name: Tests PK_Tests; Type: CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."Tests"
    ADD CONSTRAINT "PK_Tests" PRIMARY KEY ("Id");



--
-- Name: IX_Answers_QuestionId; Type: INDEX; Schema: public; Owner: quorum_user
--

CREATE INDEX "IX_Answers_QuestionId" ON public."Answers" USING btree ("QuestionId");


--
-- Name: IX_ChallengedAnswers_ChallengedQuestionId; Type: INDEX; Schema: public; Owner: quorum_user
--

CREATE INDEX "IX_ChallengedAnswers_ChallengedQuestionId" ON public."ChallengedAnswers" USING btree ("ChallengedQuestionId");


--
-- Name: IX_ChallengedAnswers_SourceAnswerId; Type: INDEX; Schema: public; Owner: quorum_user
--

CREATE INDEX "IX_ChallengedAnswers_SourceAnswerId" ON public."ChallengedAnswers" USING btree ("SourceAnswerId");


--
-- Name: IX_ChallengedQuestions_ChallengedTestId; Type: INDEX; Schema: public; Owner: quorum_user
--

CREATE INDEX "IX_ChallengedQuestions_ChallengedTestId" ON public."ChallengedQuestions" USING btree ("ChallengedTestId");


--
-- Name: IX_ChallengedQuestions_SourceQuestionId; Type: INDEX; Schema: public; Owner: quorum_user
--

CREATE INDEX "IX_ChallengedQuestions_SourceQuestionId" ON public."ChallengedQuestions" USING btree ("SourceQuestionId");


--
-- Name: IX_ChallengedTests_SourceTestId; Type: INDEX; Schema: public; Owner: quorum_user
--

CREATE INDEX "IX_ChallengedTests_SourceTestId" ON public."ChallengedTests" USING btree ("SourceTestId");


--
-- Name: IX_Questions_TestId; Type: INDEX; Schema: public; Owner: quorum_user
--

CREATE INDEX "IX_Questions_TestId" ON public."Questions" USING btree ("TestId");


--
-- Name: IX_Tags_TestId; Type: INDEX; Schema: public; Owner: quorum_user
--

CREATE INDEX "IX_Tags_TestId" ON public."Tags" USING btree ("TestId");


--
-- Name: Answers FK_Answers_Questions_QuestionId; Type: FK CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."Answers"
    ADD CONSTRAINT "FK_Answers_Questions_QuestionId" FOREIGN KEY ("QuestionId") REFERENCES public."Questions"("Id") ON DELETE CASCADE;


--
-- Name: ChallengedAnswers FK_ChallengedAnswers_Answers_SourceAnswerId; Type: FK CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."ChallengedAnswers"
    ADD CONSTRAINT "FK_ChallengedAnswers_Answers_SourceAnswerId" FOREIGN KEY ("SourceAnswerId") REFERENCES public."Answers"("Id") ON DELETE CASCADE;


--
-- Name: ChallengedAnswers FK_ChallengedAnswers_ChallengedQuestions_ChallengedQuestionId; Type: FK CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."ChallengedAnswers"
    ADD CONSTRAINT "FK_ChallengedAnswers_ChallengedQuestions_ChallengedQuestionId" FOREIGN KEY ("ChallengedQuestionId") REFERENCES public."ChallengedQuestions"("Id") ON DELETE CASCADE;


--
-- Name: ChallengedQuestions FK_ChallengedQuestions_ChallengedTests_ChallengedTestId; Type: FK CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."ChallengedQuestions"
    ADD CONSTRAINT "FK_ChallengedQuestions_ChallengedTests_ChallengedTestId" FOREIGN KEY ("ChallengedTestId") REFERENCES public."ChallengedTests"("Id") ON DELETE CASCADE;


--
-- Name: ChallengedQuestions FK_ChallengedQuestions_Questions_SourceQuestionId; Type: FK CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."ChallengedQuestions"
    ADD CONSTRAINT "FK_ChallengedQuestions_Questions_SourceQuestionId" FOREIGN KEY ("SourceQuestionId") REFERENCES public."Questions"("Id") ON DELETE CASCADE;


--
-- Name: ChallengedTests FK_ChallengedTests_Tests_SourceTestId; Type: FK CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."ChallengedTests"
    ADD CONSTRAINT "FK_ChallengedTests_Tests_SourceTestId" FOREIGN KEY ("SourceTestId") REFERENCES public."Tests"("Id") ON DELETE CASCADE;


--
-- Name: Questions FK_Questions_Tests_TestId; Type: FK CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."Questions"
    ADD CONSTRAINT "FK_Questions_Tests_TestId" FOREIGN KEY ("TestId") REFERENCES public."Tests"("Id") ON DELETE CASCADE;


--
-- Name: Tags FK_Tags_Tests_TestId; Type: FK CONSTRAINT; Schema: public; Owner: quorum_user
--

ALTER TABLE ONLY public."Tags"
    ADD CONSTRAINT "FK_Tags_Tests_TestId" FOREIGN KEY ("TestId") REFERENCES public."Tests"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--
